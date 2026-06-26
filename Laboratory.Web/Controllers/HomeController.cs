using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Laboratory.Web.Models;

namespace Laboratory.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardViewModel();

            try
            {
                var services = HttpContext.RequestServices;

                // Attempt to resolve test service
                var testServiceType = Type.GetType("Laboratory.Web.Service.IService.ITestService, Laboratory.Web");
                if (testServiceType != null)
                {
                    var testService = services.GetService(testServiceType);
                    if (testService != null)
                    {
                        var tests = InvokeGetEnumerable(testService);
                        if (tests != null)
                        {
                            model.TotalTests = CountEnumerable(tests);

                            // If test items have a NextDate or ScheduledDate, try to populate UpcomingTests
                            model.UpcomingTests = ExtractUpcomingTests(tests).ToList();
                        }
                    }
                }

                // Attempt to resolve order service
                var orderServiceType = Type.GetType("Laboratory.Web.Service.IService.IOrderService, Laboratory.Web");
                if (orderServiceType != null)
                {
                    var orderService = services.GetService(orderServiceType);
                    if (orderService != null)
                    {
                        var orders = InvokeGetEnumerable(orderService);
                        if (orders != null)
                        {
                            var orderList = ToObjectList(orders);
                            model.RecentOrders = ExtractRecentOrders(orderList);

                            model.PendingOrders = CountByStatus(orderList, "Pending");
                            model.CompletedOrders = CountByStatus(orderList, "Completed");

                            model.PendingSamples = CountByStatus(orderList, "Sample Pending") + CountByStatus(orderList, "Samples Pending");

                            // Calculate distinct patients with orders today
                            try
                            {
                                var patientsToday = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                                foreach (var o in orderList)
                                {
                                    try
                                    {
                                        var patientProp = o.GetType().GetProperty("PatientName") ?? o.GetType().GetProperty("Patient") ?? o.GetType().GetProperty("UserName") ?? o.GetType().GetProperty("PatientId");
                                        var dateProp = o.GetType().GetProperty("CreatedDate") ?? o.GetType().GetProperty("Date") ?? o.GetType().GetProperty("OrderDate");
                                        var dateObj = dateProp?.GetValue(o);
                                        DateTime? dt = null;
                                        if (dateObj is DateTime d) dt = d;
                                        else if (DateTime.TryParse(dateObj?.ToString(), out var parsed)) dt = parsed;

                                        if (dt != null && dt.Value.Date == DateTime.Today)
                                        {
                                            var patientVal = patientProp?.GetValue(o)?.ToString();
                                            if (!string.IsNullOrEmpty(patientVal)) patientsToday.Add(patientVal);
                                        }
                                    }
                                    catch { }
                                }
                                model.PatientsToday = patientsToday.Count;
                            }
                            catch { model.PatientsToday = 0; }
                        }
                    }
                }

                // Attempt to resolve cart service for cart count
                var cartServiceType = Type.GetType("Laboratory.Web.Service.IService.ICartService, Laboratory.Web");
                if (cartServiceType != null)
                {
                    var cartService = services.GetService(cartServiceType);
                    if (cartService != null)
                    {
                        // Look for GetCart or GetCartAsync method
                        var cartObj = InvokeMethodIfExists(cartService, "GetCart");
                        if (cartObj == null)
                        {
                            cartObj = InvokeMethodIfExists(cartService, "GetCartAsync", true);
                        }

                        if (cartObj != null)
                        {
                            var items = ExtractEnumerableFromObject(cartObj);
                            if (items != null)
                            {
                                model.CartItems = CountEnumerable(items);
                            }
                        }
                    }
                }
            }
            catch
            {
                // Swallow errors - dashboard should still render with defaults
            }

            // Fallbacks if no data populated
            model.TotalTests = model.TotalTests ?? 0;
            model.PendingOrders = model.PendingOrders ?? 0;
            model.CompletedOrders = model.CompletedOrders ?? 0;
            model.PendingSamples = model.PendingSamples ?? 0;
            model.CartItems = model.CartItems ?? 0;
            model.RecentOrders = model.RecentOrders ?? new List<OrderSummary>();
            model.UpcomingTests = model.UpcomingTests ?? new List<TestSummary>();

            return View(model);
        }

        private static int? CountEnumerable(IEnumerable items)
        {
            if (items == null) return null;
            var cnt = 0;
            foreach (var _ in items) cnt++;
            return cnt;
        }

        private static IEnumerable InvokeGetEnumerable(object svc)
        {
            // Try common method names
            var mnames = new[] { "GetAll", "GetAllAsync", "GetTests", "GetTestsAsync", "GetAllTests", "GetAllTestsAsync" };
            foreach (var name in mnames)
            {
                var mi = svc.GetType().GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (mi != null)
                {
                    try
                    {
                        var res = mi.Invoke(svc, mi.GetParameters().Length == 0 ? null : new object[] { });
                        // If Task returned
                        if (res is Task task)
                        {
                            task.Wait();
                            var resultProp = task.GetType().GetProperty("Result");
                            if (resultProp != null)
                            {
                                var result = resultProp.GetValue(task);
                                if (result is IEnumerable enumerable) return enumerable;
                            }
                        }
                        else if (res is IEnumerable enumerable)
                        {
                            return enumerable;
                        }
                    }
                    catch { }
                }
            }
            return null;
        }

        private static object InvokeMethodIfExists(object svc, string name, bool isAsync = false)
        {
            var mi = svc.GetType().GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (mi == null) return null;
            try
            {
                var res = mi.Invoke(svc, mi.GetParameters().Length == 0 ? null : new object[] { });
                if (res is Task task)
                {
                    task.Wait();
                    var resultProp = task.GetType().GetProperty("Result");
                    return resultProp != null ? resultProp.GetValue(task) : null;
                }
                return res;
            }
            catch { return null; }
        }

        private static List<object> ToObjectList(IEnumerable items)
        {
            var list = new List<object>();
            if (items == null) return list;
            foreach (var it in items) list.Add(it);
            return list;
        }

        private static int CountByStatus(List<object> orderList, string status)
        {
            if (orderList == null) return 0;
            var cnt = 0;
            foreach (var o in orderList)
            {
                try
                {
                    var prop = o.GetType().GetProperty("Status") ?? o.GetType().GetProperty("OrderStatus") ?? o.GetType().GetProperty("StatusName");
                    if (prop != null)
                    {
                        var val = prop.GetValue(o)?.ToString();
                        if (!string.IsNullOrEmpty(val) && val.IndexOf(status, StringComparison.OrdinalIgnoreCase) >= 0) cnt++;
                    }
                }
                catch { }
            }
            return cnt;
        }

        private static IEnumerable<TestSummary> ExtractUpcomingTests(IEnumerable tests)
        {
            var list = new List<TestSummary>();
            if (tests == null) return list;
            foreach (var t in tests)
            {
                try
                {
                    var nameProp = t.GetType().GetProperty("Name") ?? t.GetType().GetProperty("TestName") ?? t.GetType().GetProperty("Title");
                    var dateProp = t.GetType().GetProperty("NextDate") ?? t.GetType().GetProperty("ScheduledDate") ?? t.GetType().GetProperty("Date");
                    var name = nameProp?.GetValue(t)?.ToString() ?? "";
                    var dateObj = dateProp?.GetValue(t);
                    DateTime? dt = null;
                    if (dateObj is DateTime d) dt = d;
                    else if (DateTime.TryParse(dateObj?.ToString(), out var parsed)) dt = parsed;

                    if (!string.IsNullOrEmpty(name) && dt != null && dt.Value.Date >= DateTime.Today)
                    {
                        list.Add(new TestSummary { Name = name, Date = dt.Value });
                    }
                }
                catch { }

                if (list.Count >= 5) break;
            }
            return list;
        }

        private static List<OrderSummary> ExtractRecentOrders(List<object> orderList)
        {
            var list = new List<OrderSummary>();
            if (orderList == null) return list;
            foreach (var o in orderList.Take(10))
            {
                try
                {
                    var idProp = o.GetType().GetProperty("OrderId") ?? o.GetType().GetProperty("Id") ?? o.GetType().GetProperty("RequestId");
                    var patientProp = o.GetType().GetProperty("PatientName") ?? o.GetType().GetProperty("Patient") ?? o.GetType().GetProperty("UserName");
                    var testProp = o.GetType().GetProperty("TestName") ?? o.GetType().GetProperty("Test") ?? o.GetType().GetProperty("Title");
                    var statusProp = o.GetType().GetProperty("Status") ?? o.GetType().GetProperty("OrderStatus") ?? o.GetType().GetProperty("StatusName");
                    var dateProp = o.GetType().GetProperty("CreatedDate") ?? o.GetType().GetProperty("Date") ?? o.GetType().GetProperty("OrderDate");

                    var id = idProp?.GetValue(o)?.ToString() ?? "n/a";
                    var patient = patientProp?.GetValue(o)?.ToString() ?? "n/a";
                    var test = testProp?.GetValue(o)?.ToString() ?? "n/a";
                    var status = statusProp?.GetValue(o)?.ToString() ?? "n/a";
                    DateTime? dt = null;
                    var dateObj = dateProp?.GetValue(o);
                    if (dateObj is DateTime d) dt = d;
                    else if (DateTime.TryParse(dateObj?.ToString(), out var parsed)) dt = parsed;

                    list.Add(new OrderSummary
                    {
                        OrderId = id,
                        Patient = patient,
                        Test = test,
                        Status = status,
                        Date = dt
                    });
                }
                catch { }

                if (list.Count >= 5) break;
            }
            return list;
        }

        private static IEnumerable ExtractEnumerableFromObject(object obj)
        {
            if (obj is IEnumerable enumerable) return enumerable;
            // Maybe cart object has Items property
            try
            {
                var itemsProp = obj.GetType().GetProperty("Items") ?? obj.GetType().GetProperty("CartItems");
                var val = itemsProp?.GetValue(obj);
                if (val is IEnumerable e) return e;
            }
            catch { }
            return null;
        }
    }
}

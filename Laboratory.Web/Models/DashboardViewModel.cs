using System;
using System.Collections.Generic;

namespace Laboratory.Web.Models
{
    public class DashboardViewModel
    {
        public int? TotalTests { get; set; }
        public int? PendingOrders { get; set; }
        public int? CompletedOrders { get; set; }
        public int? PendingSamples { get; set; }
        public int? CartItems { get; set; }
        public int? PatientsToday { get; set; }

        public List<OrderSummary> RecentOrders { get; set; } = new List<OrderSummary>();
        public List<TestSummary> UpcomingTests { get; set; } = new List<TestSummary>();
    }

    public class OrderSummary
    {
        public string OrderId { get; set; }
        public string Patient { get; set; }
        public string Test { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
    }

    public class TestSummary
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

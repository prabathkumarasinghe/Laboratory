using Laboratory.Web.Models;
using Laboratory.Web.Service;
using Laboratory.Web.Service.IService;
using Laboratory.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Laboratory.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
		private readonly ViewRenderHelper _viewRenderHelper;
		private readonly PdfService _pdfService;
		public OrderController(IOrderService orderService,ViewRenderHelper viewRenderHelper, PdfService pdfService)
        {
            _orderService = orderService;
            _viewRenderHelper = viewRenderHelper;
            _pdfService = pdfService;
        }

        [Authorize]
        public IActionResult OrderIndex()
        {
            return View();
        }
		[Authorize]
		public IActionResult OrderEdit()
		{
			return View();
		}
		[Authorize]
		//public IActionResult Lipid()
		//{
		//	return View();
		//}
		[Authorize]
		public IActionResult LFT()
		{
			return View();
		}

		[Authorize]
        public async Task<IActionResult> OrderDetail(int orderId)
        {
            OrderHeaderDto orderHeaderDto = new OrderHeaderDto();
            string userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;

            var response = await _orderService.GetOrder(orderId);
            if (response != null && response.IsSuccess)
            {
                orderHeaderDto = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));
            }
            if (!User.IsInRole(SD.RoleAdmin) && userId != orderHeaderDto.UserId)
            {
                return NotFound();
            }
            return View(orderHeaderDto);
        }

        [Authorize]
        public IActionResult TestEdit()
        {
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        public async Task<IActionResult> Lipid()
        {
            return View();
        }

        public async Task<IActionResult> GeneratePdf(OrderHeaderDto model)
        {
            //var model = new { Name = "John Doe", Date = DateTime.Now }; // Example model


            // Render the Razor view to an HTML string
            var htmlContent = await _viewRenderHelper.RenderViewToStringAsync(this, "OrderDetail", model);

            // Convert the HTML content to a PDF
            var pdfBytes = _pdfService.GeneratePdfFromHtml(htmlContent);

            // Return the PDF file to the user
            return File(pdfBytes, "application/pdf", "GeneratedDocument.pdf");
        }


        //[HttpPost]
        //public async Task<IActionResult> TestEdit(OrderHeaderDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ResponseDto? response = await _orderService.CreateOrder(model);

        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Test created successfully";
        //            return RedirectToAction(nameof(TestIndex));
        //        }
        //        else
        //        {
        //            TempData["error"] = response?.Message;
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost("OrderReadyForPickup")]
        public async Task<IActionResult> OrderReadyForPickup(int orderId)
        {
            var response = await _orderService.UpdateOrderStatus(orderId, SD.Status_ReadyForPickup);
            if (response != null && response.IsSuccess)
            {
                //TempData["success"] = "Status updated successfully";
                //return RedirectToAction(nameof(OrderDetail), new { orderId = orderId });
            }
            return View();
        }

        [HttpPost("CompleteOrder")]
        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            var response = await _orderService.UpdateOrderStatus(orderId, SD.Status_Completed);
            if (response != null && response.IsSuccess)
            {
                //TempData["success"] = "Status updated successfully";
                //return RedirectToAction(nameof(OrderDetail), new { orderId = orderId });
            }
            return View();
        }

        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var response = await _orderService.UpdateOrderStatus(orderId, SD.Status_Cancelled);
            if (response != null && response.IsSuccess)
            {
                //TempData["success"] = "Status updated successfully";
                //return RedirectToAction(nameof(OrderDetail), new { orderId = orderId });
            }
            return View();
        }


        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeaderDto> list;
            string userId = "";
            //if (!User.IsInRole(SD.RoleAdmin))
            //{
                userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            //}
            ResponseDto response = _orderService.GetAllOrder(userId).GetAwaiter().GetResult();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderHeaderDto>>(Convert.ToString(response.Result));
                switch (status)
                {
                    case "approved":
                        list = list.Where(u => u.Status == SD.Status_Approved);
                        break;
                    case "readyforpickup":
                        list = list.Where(u => u.Status == SD.Status_ReadyForPickup);
                        break;
                    case "cancelled":
                        list = list.Where(u => u.Status == SD.Status_Cancelled || u.Status == SD.Status_Refunded);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                list = new List<OrderHeaderDto>();
            }
            return Json(new { data = list.OrderByDescending(u => u.OrderHeaderId) });
        }

        //public IActionResult SamplePdf()
        //{
        //    return View();
        //}
        //public async Task<IActionResult> SamplePdf()
        //{
        //	return View();
        //}

        //public async Task<IActionResult> GeneratePdf(MyViewModel model)
        //{
        //	//var model = new { Name = "John Doe", Date = DateTime.Now }; // Example model


        //	// Render the Razor view to an HTML string
        //	var htmlContent = await _viewRenderHelper.RenderViewToStringAsync(this, "SamplePdf", model);

        //	// Convert the HTML content to a PDF
        //	var pdfBytes = _pdfService.GeneratePdfFromHtml(htmlContent);

        //	// Return the PDF file to the user
        //	return File(pdfBytes, "application/pdf", "GeneratedDocument.pdf");
        //}

       

    }

}

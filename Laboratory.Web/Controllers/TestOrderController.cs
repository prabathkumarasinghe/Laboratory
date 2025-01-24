using Laboratory.Web.Service.IService;
using Laboratory.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Laboratory.Web.Controllers
{
    public class TestOrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ViewRenderHelper _viewRenderHelper;
        private readonly PdfService _pdfService;
        public TestOrderController(IOrderService orderService, ViewRenderHelper viewRenderHelper, PdfService pdfService)
        {
            _orderService = orderService;
            _viewRenderHelper = viewRenderHelper;
            _pdfService = pdfService;
        }
        //public IActionResult TestOrderIndex()
        //{
        //    List<CartHeaderDto>? list = new();

        //    ResponseDto? response =  _orderService.GetAllOrder();

        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<TestDto>>(Convert.ToString(response.Result));
        //    }

        //    return View(list);
        
    }
}

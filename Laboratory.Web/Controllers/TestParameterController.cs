//using Laboratory.Web.Models;
//using Laboratory.Web.Service.IService;
//using Microsoft.AspNetCore.Mvc;

//namespace Laboratory.Web.Controllers
//{
//    public class TestParameterController : Controller
//    {
//        private readonly ITestParameterService _testParameterService;
//        public TestParameterController(ITestParameterService testParameterService)
//        {
//            _testParameterService = testParameterService;
//        }


//        //public async Task<IActionResult> TestIndex()
//        //{
//        //    List<TestDto>? list = new();

//        //    ResponseDto? response = await _testService.GetAllTestsAsync();

//        //    if (response != null && response.IsSuccess)
//        //    {
//        //        list = JsonConvert.DeserializeObject<List<TestDto>>(Convert.ToString(response.Result));
//        //    }

//        //    return View(list);
//        //}

//        public async Task<IActionResult> TestEdit()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> TestEdit(ParameterDto model)
//        {
//            if (ModelState.IsValid)
//            {
//                ResponseDto? response = await _testParameterService.CreateTestParameterAsync(model);

//                if (response != null && response.IsSuccess)
//                {
//                    TempData["success"] = "Test created successfully";
//                 //   return RedirectToAction(nameof(TestIndex));
//                }
//                else
//                {
//                    TempData["error"] = response?.Message;
//                }
//            }
//            return View(model);
//        }
//    }
//}

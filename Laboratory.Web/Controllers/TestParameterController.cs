//using Laboratory.Web.Models;
//using Laboratory.Web.Service.IService;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

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
//        //    return View();
//        //}

//        public async Task<IActionResult> ParameterIndex()
//        {
//            List<ParameterDto>? list = new();

//            ResponseDto? response = await _testParameterService.GetAllTestParameterAsync();

//            if (response != null && response.IsSuccess)
//            {
//                list = JsonConvert.DeserializeObject<List<ParameterDto>>(Convert.ToString(response.Result));
//            }

//            return View(list);
//        }

//		public async Task<IActionResult> TestEdit()
//		{
//			return View();
//		}

//		[HttpPost]
//		public async Task<IActionResult> TestEdit(ParameterDto model)
//		{
//			if (ModelState.IsValid)
//			{
//				ResponseDto? response = await _testParameterService.CreateTestParameterAsync(model);

//				if (response != null && response.IsSuccess)
//				{
//					TempData["success"] = "Test created successfully";
//					return RedirectToAction(nameof(ParameterIndex));
//				}
//				else
//				{
//					TempData["error"] = response?.Message;
//				}
//			}
//			return View(model);
//		}

//		public async Task<IActionResult>  ResultUpdate(int Id)
//		{
//			ResponseDto? response = await _testParameterService.GetTestParameterByIdAsync(Id);

//			if (response != null && response.IsSuccess)
//			{
//				ParameterDto? model = JsonConvert.DeserializeObject<ParameterDto>(Convert.ToString(response.Result));
//				return View(model);
//			}

//			return NotFound();
//		}
//		//[HttpPost]
//		//public async Task<IActionResult> ResultUpdate(ParameterDto testDto)
//		//{
//		//	ResponseDto? response = await _testParameterService.UpdateTestParameterAsync(testDto);

//		//	if (response != null && response.IsSuccess)
//		//	{

//		//		return RedirectToAction(nameof(ParameterIndex));
//		//	}

//		//	return View(testDto);
//		//}

//	}
//}

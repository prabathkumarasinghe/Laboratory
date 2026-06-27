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
	public class ParameterController : Controller
	{
		private readonly ITestParameterService _testParameterService;
        private readonly ViewRenderHelper _viewRenderHelper;
        private readonly PdfService _pdfService;

        public ParameterController(ITestParameterService testParameterService, ViewRenderHelper viewRenderHelper, PdfService pdfService)
		{
			_testParameterService = testParameterService;
			_viewRenderHelper = viewRenderHelper;
			_pdfService = pdfService;
		}
        [Authorize]
        public IActionResult TestResult()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> FinalResult(int Id)
        {
            ParameterDto parameterDto = new ParameterDto();
            string userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;

            var response = await _testParameterService.GetTestParameterByIdAsync(Id);
            if (response != null && response.IsSuccess)
            {
                parameterDto = JsonConvert.DeserializeObject<ParameterDto>(Convert.ToString(response.Result));
            }
            //if (!User.IsInRole(SD.RoleAdmin) && userId != orderHeaderDto.UserId)
            //{
            //    return NotFound();
            //}
            return View(parameterDto);
        }

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<ParameterDto> list;
            string userId = "";
            //if (!User.IsInRole(SD.RoleAdmin))
            //{
            userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            //}
            ResponseDto response = _testParameterService.GetAllTestParameterAsync().GetAwaiter().GetResult();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ParameterDto>>(Convert.ToString(response.Result));
				//switch (status)
				//{
				//	case "approved":
				//		list = list.Where(u => u.Status == SD.Status_Approved);
				//		break;
				//	case "readyforpickup":
				//		list = list.Where(u => u.Status == SD.Status_ReadyForPickup);
				//		break;
				//	case "cancelled":
				//		list = list.Where(u => u.Status == SD.Status_Cancelled || u.Status == SD.Status_Refunded);
				//		break;
				//	default:
				//		break;
				//}
			}
			else
			{
				list = new List<ParameterDto>();
			}
			return Json(new { data = list });
        }
        [Authorize]
        public async Task<IActionResult> ParameterIndex()
		{
			List<ParameterDto>? list = new();

			//ResponseDto? response = await _testParameterService.GetAllTestParameterAsync();
			ResponseDto? response = await _testParameterService.GetAllTestParameterAsync();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ParameterDto>>(Convert.ToString(response.Result));
			}

			return View(list);
		}
        //      [Authorize]
        //      public async Task<IActionResult> TestEdit()
        //{
        //	return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> TestEdit(ParameterDto model)
        //{
        //	if (ModelState.IsValid)
        //	{
        //		ResponseDto? response = await _testParameterService.CreateTestParameterAsync(model);

        //		if (response != null && response.IsSuccess)
        //		{
        //			TempData["success"] = "Test created successfully";
        //			return RedirectToAction(nameof(ParameterIndex));
        //		}
        //		else
        //		{
        //			TempData["error"] = response?.Message;
        //		}
        //	}
        //	return View(model);
        //}

        [Authorize]
        public IActionResult TestEdit()
        {
            ParameterDto model = new ParameterDto();

            model.SelectedTests = new List<string>();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TestEdit(ParameterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Make sure at least one test is selected
            if (model.SelectedTests == null || !model.SelectedTests.Any())
            {
                ModelState.AddModelError("", "Please select at least one laboratory test.");
                return View(model);
            }

            bool allSuccess = true;

            foreach (var test in model.SelectedTests)
            {
                ParameterDto dto = new ParameterDto
                {
                    // Patient Information
                    PatientName = model.PatientName,
                    Age = model.Age,
                    DOB = model.DOB,
                    Sex = model.Sex,
                    Phone = model.Phone,
                    Email = model.Email,
                    

                    // Laboratory Information
                    RefNumber = model.RefNumber,
                    LabNumber = model.LabNumber,
                    CollectedDate = model.CollectedDate,
                    ReceivedDate = model.ReceivedDate,
                    ReportedDate = model.ReportedDate,

                    // Selected Test
                    TestType = test
                };

                ResponseDto? response =
                    await _testParameterService.CreateTestParameterAsync(dto);

                if (response == null || !response.IsSuccess)
                {
                    allSuccess = false;
                }
            }

            if (allSuccess)
            {
                TempData["success"] = "Patient and selected laboratory tests saved successfully.";
                return RedirectToAction(nameof(ParameterIndex));
            }

            TempData["error"] = "Some laboratory tests could not be saved.";

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> TestDelete(int testId)
		{
			ResponseDto? response = await _testParameterService.GetTestParameterByIdAsync(testId);

			if (response != null && response.IsSuccess)
			{
				TestDto? model = JsonConvert.DeserializeObject<TestDto>(Convert.ToString(response.Result));
				return View(model);
			}

			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> TestDelete(ParameterDto testDto)
		{
			ResponseDto? response = await _testParameterService.DeleteTestParameterAsync(testDto.Id);

			if (response != null && response.IsSuccess)
			{

				return RedirectToAction(nameof(ParameterIndex));
			}

			return View(testDto);
		}
        //[Authorize]
        public async Task<IActionResult> ResultUpdate(int testId)
		{
			ResponseDto? response = await _testParameterService.GetTestParameterByIdAsync(testId);

			if (response != null && response.IsSuccess)
			{
				ParameterDto? model = JsonConvert.DeserializeObject<ParameterDto>(Convert.ToString(response.Result));
				return View(model);
			}

			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> ResultUpdate(ParameterDto parameterDto)
		{
			ResponseDto? response = await _testParameterService.UpdateTestParameterAsync(parameterDto);

			if (response != null && response.IsSuccess)
			{

				return RedirectToAction(nameof(ParameterIndex));
			}

			return View(parameterDto);
		}

        public async Task<IActionResult> GeneratePdf(ParameterDto model)
        {
            //var model = new { Name = "John Doe", Date = DateTime.Now }; // Example model


            // Render the Razor view to an HTML string
            var htmlContent = await _viewRenderHelper.RenderViewToStringAsync(this, "FinalResult", model);

            // Convert the HTML content to a PDF
            var pdfBytes = _pdfService.GeneratePdfFromHtml(htmlContent);

            // Return the PDF file to the user
            return File(pdfBytes, "application/pdf", "GeneratedDocument.pdf");
        }

        [HttpGet]
        public async Task<IActionResult> ResultDelete(int testId)
        {
            ResponseDto? response = await _testParameterService.GetTestParameterByIdAsync(testId);

            if (response != null && response.IsSuccess)
            {
                ParameterDto? model = JsonConvert.DeserializeObject<ParameterDto>(
                    Convert.ToString(response.Result));

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ResultDelete(ParameterDto parameterDto)
        {
            ResponseDto? response = await _testParameterService.DeleteTestParameterAsync(parameterDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Result deleted successfully.";
                return RedirectToAction(nameof(ParameterIndex));
            }

            TempData["error"] = response?.Message;
            return View(parameterDto);
        }
    }
}

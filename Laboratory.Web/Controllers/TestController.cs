using Laboratory.Web.Models;
using Laboratory.Web.Service;
using Laboratory.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Laboratory.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;
		private readonly ViewRenderHelper _viewRenderHelper;
		private readonly PdfService _pdfService;
		public TestController(ITestService testService, ViewRenderHelper viewRenderHelper, PdfService pdfService)
        {
            _testService = testService;
            _viewRenderHelper = viewRenderHelper;
            _pdfService = pdfService;
        }


        public async Task<IActionResult> TestIndex()
        {
            List<TestDto>? list = new();

            ResponseDto? response = await _testService.GetAllTestsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TestDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> TestCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestCreate(TestDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _testService.CreateTestsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Test created successfully";
                    return RedirectToAction(nameof(TestIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        public async Task<IActionResult> TestDelete(int testId)
        {
            ResponseDto? response = await _testService.GetTestByIdAsync(testId);

            if (response != null && response.IsSuccess)
            {
                TestDto? model = JsonConvert.DeserializeObject<TestDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> TestDelete(TestDto testDto)
        {
            ResponseDto? response = await _testService.DeleteTestsAsync(testDto.TestId);

            if (response != null && response.IsSuccess)
            {

                return RedirectToAction(nameof(TestIndex));
            }

            return View(testDto);
        }

        public async Task<IActionResult> TestUpdate(int testId)
        {
            ResponseDto? response = await _testService.GetTestByIdAsync(testId);

            if (response != null && response.IsSuccess)
            {
                TestDto? model = JsonConvert.DeserializeObject<TestDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> TestUpdate(TestDto testDto)
        {
            ResponseDto? response = await _testService.UpdateTestsAsync(testDto);

            if (response != null && response.IsSuccess)
            {

                return RedirectToAction(nameof(TestIndex));
            }

            return View(testDto);
        }
		public async Task<IActionResult> Report()
		{
			return View();
		}
        public async Task<IActionResult> Lipid()
        {
            return View();
        }

        public async Task<IActionResult> GeneratePdf()
		{
			//var model = new { Name = "John Doe", Date = DateTime.Now }; // Example model


			// Render the Razor view to an HTML string
			var htmlContent = await _viewRenderHelper.RenderViewToStringAsync(this, "Report", null);

			// Convert the HTML content to a PDF
			var pdfBytes = _pdfService.GeneratePdfFromHtml(htmlContent);

			// Return the PDF file to the user
			return File(pdfBytes, "application/pdf", "GeneratedDocument.pdf");
		}
	}
}

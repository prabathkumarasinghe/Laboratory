using Laboratory.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Laboratory.Web.Controllers
{
    public class PdfController : Controller
    {
        private readonly ViewRenderHelper _viewRenderHelper;
        private readonly PdfService _pdfService;

        public PdfController(ViewRenderHelper viewRenderHelper, PdfService pdfService)
        {
            _viewRenderHelper = viewRenderHelper;
            _pdfService = pdfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> GeneratePdf()
        //{
        //    var model = new { Name = "John Doe", Date = DateTime.Now }; // Example model

        //    // Render the Razor view to an HTML string
        //    var htmlContent = await _viewRenderHelper.RenderViewToStringAsync(this, "SamplePdf", model);

        //    // Convert the HTML content to a PDF
        //    var pdfBytes = _pdfService.GeneratePdfFromHtml(htmlContent);

        //    // Return the PDF file to the user
        //    return File(pdfBytes, "application/pdf", "GeneratedDocument.pdf");
        //}
    }
}

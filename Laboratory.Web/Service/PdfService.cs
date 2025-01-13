using iText.Html2pdf;

namespace Laboratory.Web.Service
{
    public class PdfService
    {
        public byte[] GeneratePdfFromHtml(string htmlContent)
        {
            using var memoryStream = new MemoryStream();

            // Convert HTML to PDF
            HtmlConverter.ConvertToPdf(htmlContent, memoryStream);

            return memoryStream.ToArray();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Laboratory.Web.Service
{
    public class ViewRenderHelper
    {
        private readonly ICompositeViewEngine _viewEngine;

        public ViewRenderHelper(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        public async Task<string> RenderViewToStringAsync(Controller controller, string viewName, object model)
        {
            var viewResult = _viewEngine.FindView(controller.ControllerContext, viewName, false);

            if (!viewResult.Success)
            {
                throw new FileNotFoundException($"View '{viewName}' not found.");
            }

            controller.ViewData.Model = model;

            using var writer = new StringWriter();
            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult.View,
                controller.ViewData,
                controller.TempData,
                writer,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return writer.GetStringBuilder().ToString();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.EstateAgent.ViewComponents.Layout
{
    public class _EstateAgentHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

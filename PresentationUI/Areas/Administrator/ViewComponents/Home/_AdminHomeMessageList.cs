using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.ViewComponents.Home
{
    public class _AdminHomeMessageList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

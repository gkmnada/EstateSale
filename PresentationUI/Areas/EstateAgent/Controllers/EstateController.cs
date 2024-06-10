using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class EstateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

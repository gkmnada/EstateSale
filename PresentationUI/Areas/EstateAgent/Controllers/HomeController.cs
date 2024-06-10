using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.EstateAgent.Controllers
{
    [Authorize]
    [Area("EstateAgent")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

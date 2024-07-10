using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.StatisticServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private readonly IStatisticService _statisticService;

        public HomeController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryCount = await _statisticService.GetActiveCategoryCountAsync();
            ViewBag.CategoryCount = categoryCount;

            var estateCount = await _statisticService.GetEstateCountAsync();
            ViewBag.EstateCount = estateCount;

            var avgEstatePriceByRent = await _statisticService.GetAverageEstatePriceByRentAsync();
            ViewBag.AverageEstatePriceByRent = Math.Round(avgEstatePriceByRent, 2);

            var avgEstatePriceBySale = await _statisticService.GetAverageEstatePriceBySaleAsync();
            ViewBag.AverageEstatePriceBySale = Math.Round(avgEstatePriceBySale, 2);

            return View();
        }
    }
}

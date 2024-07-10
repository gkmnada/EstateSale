using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.PopularLocationDto;
using PresentationUI.Services.PopularLocationServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class LocationController : Controller
    {
        private readonly IPopularLocationService _popularLocationService;

        public LocationController(IPopularLocationService popularLocationService)
        {
            _popularLocationService = popularLocationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _popularLocationService.ListPopularLocationAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _popularLocationService.CreatePopularLocationAsync(createPopularLocationDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _popularLocationService.DeletePopularLocationAsync(id);
            return RedirectToAction("Index", "Location", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var values = await _popularLocationService.GetPopularLocationsAsync(id);

            var locationViewModel = new LocationViewModel
            {
                GetPopularLocationDto = values
            };
            return View(locationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _popularLocationService.UpdatePopularLocationAsync(updatePopularLocationDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }
    }
}

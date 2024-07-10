using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.AboutDto;
using PresentationUI.Services.AboutServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.ListAboutAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "About", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _aboutService.GetAboutAsync(id);

            var aboutViewModel = new AboutViewModel
            {
                GetAboutDto = values
            };
            return View(aboutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "About", new { area = "Administrator" });
            }
            return View();
        }
    }
}

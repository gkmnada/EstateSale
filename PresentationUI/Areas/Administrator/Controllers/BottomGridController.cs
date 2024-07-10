using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.BottomGridDto;
using PresentationUI.Services.BottomGridServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class BottomGridController : Controller
    {
        private readonly IBottomGridService _bottomGridService;

        public BottomGridController(IBottomGridService bottomGridService)
        {
            _bottomGridService = bottomGridService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bottomGridService.ListBottomGridAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBottomGrid()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridService.CreateBottomGridAsync(createBottomGridDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "BottomGrid", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridService.DeleteBottomGridAsync(id);
            return RedirectToAction("Index", "BottomGrid", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBottomGrid(int id)
        {
            var values = await _bottomGridService.GetBottomGridAsync(id);

            var bottomGridViewModel = new BottomGridViewModel
            {
                GetBottomGridDto = values
            };
            return View(bottomGridViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridService.UpdateBottomGridAsync(updateBottomGridDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "BottomGrid", new { area = "Administrator" });
            }
            return View();
        }
    }
}


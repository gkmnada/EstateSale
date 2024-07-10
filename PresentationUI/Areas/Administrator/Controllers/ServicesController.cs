using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.ServiceDto;
using PresentationUI.Services.ServiceServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _serviceService.ListServiceAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceService.CreateServiceAsync(createServiceDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Services", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction("Index", "Services", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var values = await _serviceService.GetServiceAsync(id);

            var servicesViewModel = new ServicesViewModel
            {
                GetServiceDto = values
            };
            return View(servicesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceService.UpdateServiceAsync(updateServiceDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Services", new { area = "Administrator" });
            }
            return View();
        }
    }
}

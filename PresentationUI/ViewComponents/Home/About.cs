using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.AboutServices;
using PresentationUI.Services.ServiceServices;

namespace PresentationUI.ViewComponents.Home
{
    public class About : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IServiceService _serviceService;

        public About(IAboutService aboutService, IServiceService serviceService)
        {
            _aboutService = aboutService;
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.ListAboutAsync();

            ViewBag.Image = values.Select(x => x.image).FirstOrDefault();
            ViewBag.Title = values.Select(x => x.title).FirstOrDefault();
            ViewBag.Subtitle = values.Select(x => x.subtitle).FirstOrDefault();
            ViewBag.Description1 = values.Select(x => x.description1).FirstOrDefault();
            ViewBag.Description2 = values.Select(x => x.description2).FirstOrDefault();

            var services = await _serviceService.ListServiceAsync();
            return View(services);
        }
    }
}

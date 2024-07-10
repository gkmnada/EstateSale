using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.PopularLocationServices;

namespace PresentationUI.ViewComponents.Home
{
    public class PopularLocation : ViewComponent
    {
        private readonly IPopularLocationService _popularLocationService;

        public PopularLocation(IPopularLocationService popularLocationService)
        {
            _popularLocationService = popularLocationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _popularLocationService.ListPopularLocationAsync();
            return View(values);
        }
    }
}

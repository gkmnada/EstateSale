using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.EstateServices;

namespace PresentationUI.Areas.Administrator.ViewComponents.Home
{
    public class _AdminHomeEstateList : ViewComponent
    {
        private readonly IEstateService _estateService;

        public _AdminHomeEstateList(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _estateService.ListLastEstateAsync();
            return View(values);
        }
    }
}

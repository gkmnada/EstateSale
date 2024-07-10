using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.EstateServices;

namespace PresentationUI.ViewComponents.Home
{
    public class EstateList : ViewComponent
    {
        private readonly IEstateService _estateService;

        public EstateList(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _estateService.ListEstateWithCategoryAsync();
            return View(values);
        }
    }
}

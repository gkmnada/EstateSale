using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.BottomGridServices;

namespace PresentationUI.ViewComponents.Home
{
    public class BottomGrid : ViewComponent
    {
        private readonly IBottomGridService _bottomGridService;

        public BottomGrid(IBottomGridService bottomGridService)
        {
            _bottomGridService = bottomGridService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bottomGridService.ListBottomGridAsync();
            return View(values);
        }
    }
}

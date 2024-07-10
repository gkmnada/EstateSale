using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.ContactServices;

namespace PresentationUI.Areas.Administrator.ViewComponents.Home
{
    public class _AdminHomeMessageList : ViewComponent
    {
        private readonly IContactService _contactService;

        public _AdminHomeMessageList(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactService.ListLastContactAsync();
            return View(values);
        }
    }
}

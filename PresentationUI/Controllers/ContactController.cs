using Microsoft.AspNetCore.Mvc;
using PresentationUI.Dtos.ContactDto;
using PresentationUI.Services.ContactServices;

namespace PresentationUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}

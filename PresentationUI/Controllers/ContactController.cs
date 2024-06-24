using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.ContactDto;
using System.Text;

namespace PresentationUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7071/api/Contact", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}

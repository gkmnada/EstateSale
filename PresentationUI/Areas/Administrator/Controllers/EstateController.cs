using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.EstateDto;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class EstateController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public EstateController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Estate");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateWithCategoryDto>>(json);
                return View(values);
            }
            return View();
        }
    }
}

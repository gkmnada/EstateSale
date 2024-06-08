using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/Statistic/GetActiveCategoryCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.CategoryCount = values;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7071/api/Statistic/GetEstateCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.EstateCount = values;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7071/api/Statistic/GetAverageEstatePriceByRent");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<decimal>(jsonData);
                ViewBag.AverageEstatePriceByRent = Math.Round(values, 2);
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7071/api/Statistic/GetAverageEstatePriceBySale");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<decimal>(jsonData);
                ViewBag.AverageEstatePriceBySale = Math.Round(values, 2);
            }

            return View();
        }
    }
}

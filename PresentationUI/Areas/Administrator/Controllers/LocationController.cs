using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.PopularLocationDto;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public LocationController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/PopularLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPopularLocationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7071/api/PopularLocation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7071/api/PopularLocation?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/PopularLocation/GetPopularLocation?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetPopularLocationDto>(jsonData);

                var locationViewModel = new LocationViewModel
                {
                    GetPopularLocationDto = values
                };
                return View(locationViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePopularLocationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7071/api/PopularLocation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }
    }
}

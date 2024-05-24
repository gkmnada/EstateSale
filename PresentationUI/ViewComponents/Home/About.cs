using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.AboutDto;
using PresentationUI.Dtos.ServiceDto;

namespace PresentationUI.ViewComponents.Home
{
    public class About : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public About(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

                ViewBag.Image = values.Select(x => x.image).FirstOrDefault();
                ViewBag.Title = values.Select(x => x.title).FirstOrDefault();
                ViewBag.Subtitle = values.Select(x => x.subtitle).FirstOrDefault();
                ViewBag.Description1 = values.Select(x => x.description1).FirstOrDefault();
                ViewBag.Description2 = values.Select(x => x.description2).FirstOrDefault();

                var response = await client.GetAsync("https://localhost:7071/api/Service");
                var json = await response.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(json);
                return View(services);
            }
            return View();
        }
    }
}

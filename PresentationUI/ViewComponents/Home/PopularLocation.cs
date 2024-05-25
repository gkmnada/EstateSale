using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.PopularLocationDto;

namespace PresentationUI.ViewComponents.Home
{
    public class PopularLocation : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public PopularLocation(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/PopularLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var popularLocation = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(popularLocation);
            }
            return View();
        }
    }
}

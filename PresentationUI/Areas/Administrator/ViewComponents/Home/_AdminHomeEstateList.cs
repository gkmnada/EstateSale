using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.EstateDto;

namespace PresentationUI.Areas.Administrator.ViewComponents.Home
{
    public class _AdminHomeEstateList : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _AdminHomeEstateList(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/Estate/ListLastEstate");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

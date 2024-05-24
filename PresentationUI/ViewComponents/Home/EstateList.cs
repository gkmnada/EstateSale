using Microsoft.AspNetCore.Mvc;
using PresentationUI.Dtos.EstateDto;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.Home
{
    public class EstateList : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public EstateList(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/Estate/ListEstateWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var estates = JsonConvert.DeserializeObject<List<ResultEstateWithCategoryDto>>(jsonData);
                return View(estates);
            }
            return View();
        }
    }
}

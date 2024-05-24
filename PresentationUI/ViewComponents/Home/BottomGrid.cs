using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.BottomGridDto;

namespace PresentationUI.ViewComponents.Home
{
    public class BottomGrid : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public BottomGrid(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/BottomGrid");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

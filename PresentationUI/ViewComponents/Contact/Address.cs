using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.AddressDto;

namespace PresentationUI.ViewComponents.Contact
{
    public class Address : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public Address(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Address");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

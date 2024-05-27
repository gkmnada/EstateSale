using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.TestimonialDto;

namespace PresentationUI.ViewComponents.Home
{
    public class Testimonial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public Testimonial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(json);
                return View(values);
            }
            return View();
        }
    }
}

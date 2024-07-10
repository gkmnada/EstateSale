using PresentationUI.Dtos.TestimonialDto;

namespace PresentationUI.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly HttpClient _httpClient;

        public TestimonialService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            await _httpClient.PostAsJsonAsync("testimonial", createTestimonialDto);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            await _httpClient.DeleteAsync("testimonial?id=" + id);
        }

        public async Task<GetTestimonialDto> GetTestimonialAsync(int id)
        {
            var response = await _httpClient.GetAsync("testimonial/gettestimonial?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetTestimonialDto>();
        }

        public async Task<List<ResultTestimonialDto>> ListTestimonialAsync()
        {
            var response = await _httpClient.GetAsync("testimonial");
            return await response.Content.ReadFromJsonAsync<List<ResultTestimonialDto>>();
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            await _httpClient.PutAsJsonAsync("testimonial", updateTestimonialDto);
        }
    }
}

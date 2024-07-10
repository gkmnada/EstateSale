using PresentationUI.Dtos.AboutDto;

namespace PresentationUI.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("about", createAboutDto);
        }

        public async Task DeleteAboutAsync(int id)
        {
            await _httpClient.DeleteAsync("about?id=" + id);
        }

        public async Task<GetAboutDto> GetAboutAsync(int id)
        {
            var response = await _httpClient.GetAsync("about/getabout?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetAboutDto>();
        }

        public async Task<List<ResultAboutDto>> ListAboutAsync()
        {
            var response = await _httpClient.GetAsync("about");
            return await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("about", updateAboutDto);
        }
    }
}

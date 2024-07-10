using PresentationUI.Dtos.PopularLocationDto;

namespace PresentationUI.Services.PopularLocationServices
{
    public class PopularLocationService : IPopularLocationService
    {
        private readonly HttpClient _httpClient;

        public PopularLocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            await _httpClient.PostAsJsonAsync("popularlocation", createPopularLocationDto);
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            await _httpClient.DeleteAsync("popularlocation?id=" + id);
        }

        public async Task<GetPopularLocationDto> GetPopularLocationsAsync(int id)
        {
            var response = await _httpClient.GetAsync("popularlocation/getpopularlocation?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetPopularLocationDto>();
        }

        public async Task<List<ResultPopularLocationDto>> ListPopularLocationAsync()
        {
            var response = await _httpClient.GetAsync("popularlocation");
            return await response.Content.ReadFromJsonAsync<List<ResultPopularLocationDto>>();
        }

        public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _httpClient.PutAsJsonAsync("popularlocation", updatePopularLocationDto);
        }
    }
}

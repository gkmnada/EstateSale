using PresentationUI.Dtos.SocialMediaDto;

namespace PresentationUI.Services.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly HttpClient _httpClient;

        public SocialMediaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            await _httpClient.PostAsJsonAsync("socialmedia", createSocialMediaDto);
        }

        public async Task DeleteSocialMediaAsync(int id)
        {
            await _httpClient.DeleteAsync("socialmedia?id=" + id);
        }

        public async Task<GetSocialMediaDto> GetSocialMediaAsync(int id)
        {
            var response = await _httpClient.GetAsync("socialmedia/getsocialmedia?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetSocialMediaDto>();
        }

        public async Task<List<ResultSocialMediaDto>> ListSocialMediaAsync()
        {
            var response = await _httpClient.GetAsync("socialmedia");
            return await response.Content.ReadFromJsonAsync<List<ResultSocialMediaDto>>();
        }

        public async Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _httpClient.PutAsJsonAsync("socialmedia", updateSocialMediaDto);
        }
    }
}

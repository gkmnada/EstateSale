using PresentationUI.Dtos.BottomGridDto;

namespace PresentationUI.Services.BottomGridServices
{
    public class BottomGridService : IBottomGridService
    {
        private readonly HttpClient _httpClient;

        public BottomGridService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            await _httpClient.PostAsJsonAsync("bottomgrid", createBottomGridDto);
        }

        public async Task DeleteBottomGridAsync(int id)
        {
            await _httpClient.DeleteAsync("bottomgrid?id=" + id);
        }

        public async Task<GetBottomGridDto> GetBottomGridAsync(int id)
        {
            var response = await _httpClient.GetAsync("bottomgrid/getbottomgrid?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetBottomGridDto>();
        }

        public async Task<List<ResultBottomGridDto>> ListBottomGridAsync()
        {
            var response = await _httpClient.GetAsync("bottomgrid");
            return await response.Content.ReadFromJsonAsync<List<ResultBottomGridDto>>();
        }

        public async Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            await _httpClient.PutAsJsonAsync("bottomgrid", updateBottomGridDto);
        }
    }
}

using PresentationUI.Dtos.EstateDetailDto;

namespace PresentationUI.Services.EstateDetailServices
{
    public class EstateDetailService : IEstateDetailService
    {
        private readonly HttpClient _httpClient;

        public EstateDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateEstateDetailAsync(CreateEstateDetailDto createEstateDetailDto)
        {
            await _httpClient.PostAsJsonAsync("estatedetail", createEstateDetailDto);
        }

        public async Task DeleteEstateDetailAsync(int id)
        {
            await _httpClient.DeleteAsync("estatedetail?id=" + id);
        }

        public async Task<GetEstateDetailDto> GetEstateDetailAsync(int id)
        {
            var response = await _httpClient.GetAsync("estatedetail/getestatedetail?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetEstateDetailDto>();
        }

        public async Task<List<ResultEstateDetailDto>> ListEstateDetailAsync()
        {
            var response = await _httpClient.GetAsync("estatedetail");
            return await response.Content.ReadFromJsonAsync<List<ResultEstateDetailDto>>();
        }

        public async Task UpdateEstateDetailAsync(UpdateEstateDetailDto updateEstateDetailDto)
        {
            await _httpClient.PutAsJsonAsync("estatedetail", updateEstateDetailDto);
        }
    }
}

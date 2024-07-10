using PresentationUI.Dtos.EstateDto;

namespace PresentationUI.Services.EstateServices
{
    public class EstateService : IEstateService
    {
        private readonly HttpClient _httpClient;

        public EstateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateEstateAsync(CreateEstateDto createEstateDto)
        {
            await _httpClient.PostAsJsonAsync("estate", createEstateDto);
        }

        public async Task DeleteEstateAsync(int id)
        {
            await _httpClient.DeleteAsync("estate?id=" + id);
        }

        public async Task<GetEstateDto> GetEstateAsync(int id)
        {
            var response = await _httpClient.GetAsync("estate/getestate?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetEstateDto>();
        }

        public async Task<List<ResultEstateDto>> ListEstateAsync()
        {
            var response = await _httpClient.GetAsync("estate");
            return await response.Content.ReadFromJsonAsync<List<ResultEstateDto>>();
        }

        public async Task<List<ResultEstateWithCategoryDto>> ListEstateByEstateAgentAsync(int id)
        {
            var response = await _httpClient.GetAsync("estate/listestatebyestateagent?id=" + id);
            return await response.Content.ReadFromJsonAsync<List<ResultEstateWithCategoryDto>>();
        }

        public async Task<List<ResultEstateWithCategoryDto>> ListEstateWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("estate/listestatewithcategory");
            return await response.Content.ReadFromJsonAsync<List<ResultEstateWithCategoryDto>>();
        }

        public async Task<List<ResultEstateWithCategoryDto>> ListLastEstateAsync()
        {
            var response = await _httpClient.GetAsync("estate/listlastestate");
            return await response.Content.ReadFromJsonAsync<List<ResultEstateWithCategoryDto>>();
        }

        public async Task UpdateDealOfDayChangeToFalseAsync(int id)
        {
            await _httpClient.GetAsync("estate/updatedealofdaychangetofalse?id=" + id);
        }

        public async Task UpdateDealOfDayChangeToTrueAsync(int id)
        {
            await _httpClient.GetAsync("estate/updatedealofdaychangetotrue?id=" + id);
        }

        public async Task UpdateEstateAsync(UpdateEstateDto updateEstateDto)
        {
            await _httpClient.PutAsJsonAsync("estate", updateEstateDto);
        }
    }
}

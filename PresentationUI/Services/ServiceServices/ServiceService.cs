using PresentationUI.Dtos.ServiceDto;

namespace PresentationUI.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient _httpClient;

        public ServiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            await _httpClient.PostAsJsonAsync("service", createServiceDto);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _httpClient.DeleteAsync("service?id=" + id);
        }

        public async Task<GetServiceDto> GetServiceAsync(int id)
        {
            var response = await _httpClient.GetAsync("service/getservice?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetServiceDto>();
        }

        public async Task<List<ResultServiceDto>> ListServiceAsync()
        {
            var response = await _httpClient.GetAsync("service");
            return await response.Content.ReadFromJsonAsync<List<ResultServiceDto>>();
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            await _httpClient.PutAsJsonAsync("service", updateServiceDto);
        }
    }
}

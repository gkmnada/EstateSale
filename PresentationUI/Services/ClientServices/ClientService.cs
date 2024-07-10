using PresentationUI.Dtos.ClientDto;

namespace PresentationUI.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateClientAsync(CreateClientDto createClientDto)
        {
            await _httpClient.PostAsJsonAsync("client", createClientDto);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _httpClient.DeleteAsync("client?id=" + id);
        }

        public async Task<GetClientDto> GetClientAsync(int id)
        {
            var response = await _httpClient.GetAsync("client/getclient?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetClientDto>();
        }

        public async Task<List<ResultClientDto>> ListClientAsync()
        {
            var response = await _httpClient.GetAsync("client");
            return await response.Content.ReadFromJsonAsync<List<ResultClientDto>>();
        }

        public async Task UpdateClientAsync(UpdateClientDto updateClientDto)
        {
            await _httpClient.PutAsJsonAsync("client", updateClientDto);
        }
    }
}

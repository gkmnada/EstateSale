using PresentationUI.Dtos.AddressDto;

namespace PresentationUI.Services.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
        {
            await _httpClient.PostAsJsonAsync("address", createAddressDto);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _httpClient.DeleteAsync("address?id=" + id);
        }

        public async Task<GetAddressDto> GetAddressAsync(int id)
        {
            var response = await _httpClient.GetAsync("address/getaddress?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetAddressDto>();
        }

        public async Task<List<ResultAddressDto>> ListAddressAsync()
        {
            var response = await _httpClient.GetAsync("address");
            return await response.Content.ReadFromJsonAsync<List<ResultAddressDto>>();
        }

        public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
        {
            await _httpClient.PutAsJsonAsync("address", updateAddressDto);
        }
    }
}

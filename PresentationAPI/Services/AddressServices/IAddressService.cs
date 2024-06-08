using PresentationAPI.Dtos.AddressDto;

namespace PresentationAPI.Services.AddressServices
{
    public interface IAddressService
    {
        Task<List<ResultAddressDto>> ListAddressAsync();
        Task CreateAddressAsync(CreateAddressDto createAddressDto);
        Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
        Task DeleteAddressAsync(int id);
        Task<GetAddressDto> GetAddressAsync(int id);
    }
}

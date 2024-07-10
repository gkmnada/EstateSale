using PresentationUI.Dtos.ClientDto;

namespace PresentationUI.Services.ClientServices
{
    public interface IClientService
    {
        Task<List<ResultClientDto>> ListClientAsync();
        Task CreateClientAsync(CreateClientDto createClientDto);
        Task UpdateClientAsync(UpdateClientDto updateClientDto);
        Task DeleteClientAsync(int id);
        Task<GetClientDto> GetClientAsync(int id);
    }
}

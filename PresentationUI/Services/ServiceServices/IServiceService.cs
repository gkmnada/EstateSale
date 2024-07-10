using PresentationUI.Dtos.ServiceDto;

namespace PresentationUI.Services.ServiceServices
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> ListServiceAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(int id);
        Task<GetServiceDto> GetServiceAsync(int id);
    }
}

using PresentationUI.Dtos.EstateDetailDto;

namespace PresentationUI.Services.EstateDetailServices
{
    public interface IEstateDetailService
    {
        Task<List<ResultEstateDetailDto>> ListEstateDetailAsync();
        Task CreateEstateDetailAsync(CreateEstateDetailDto createEstateDetailDto);
        Task UpdateEstateDetailAsync(UpdateEstateDetailDto updateEstateDetailDto);
        Task DeleteEstateDetailAsync(int id);
        Task<GetEstateDetailDto> GetEstateDetailAsync(int id);
    }
}

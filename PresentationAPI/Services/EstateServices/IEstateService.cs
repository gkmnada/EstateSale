using PresentationAPI.Dtos.EstateDto;

namespace PresentationAPI.Services.EstateServices
{
    public interface IEstateService
    {
        Task<List<ResultEstateDto>> ListEstateAsync();
        Task CreateEstateAsync(CreateEstateDto createEstateDto);
        Task UpdateEstateAsync(UpdateEstateDto updateEstateDto);
        Task DeleteEstateAsync(int id);
        Task<GetEstateDto> GetEstateAsync(int id);
        Task<List<ResultEstateWithCategoryDto>> ListEstateWithCategoryAsync();
    }
}

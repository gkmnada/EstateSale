using PresentationUI.Dtos.EstateDto;

namespace PresentationUI.Services.EstateServices
{
    public interface IEstateService
    {
        Task<List<ResultEstateDto>> ListEstateAsync();
        Task CreateEstateAsync(CreateEstateDto createEstateDto);
        Task UpdateEstateAsync(UpdateEstateDto updateEstateDto);
        Task DeleteEstateAsync(int id);
        Task<GetEstateDto> GetEstateAsync(int id);
        Task<List<ResultEstateWithCategoryDto>> ListEstateWithCategoryAsync();
        Task UpdateDealOfDayChangeToTrueAsync(int id);
        Task UpdateDealOfDayChangeToFalseAsync(int id);
        Task<List<ResultEstateWithCategoryDto>> ListLastEstateAsync();
        Task<List<ResultEstateWithCategoryDto>> ListEstateByEstateAgentAsync(int id);
    }
}

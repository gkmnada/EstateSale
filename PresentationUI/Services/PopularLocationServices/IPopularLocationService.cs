using PresentationUI.Dtos.PopularLocationDto;

namespace PresentationUI.Services.PopularLocationServices
{
    public interface IPopularLocationService
    {
        Task<List<ResultPopularLocationDto>> ListPopularLocationAsync();
        Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto);
        Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto);
        Task DeletePopularLocationAsync(int id);
        Task<GetPopularLocationDto> GetPopularLocationsAsync(int id);
    }
}

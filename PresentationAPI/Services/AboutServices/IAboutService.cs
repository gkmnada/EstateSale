using PresentationAPI.Dtos.AboutDto;

namespace PresentationAPI.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> ListAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(int id);
        Task<GetAboutDto> GetAboutAsync(int id);
    }
}

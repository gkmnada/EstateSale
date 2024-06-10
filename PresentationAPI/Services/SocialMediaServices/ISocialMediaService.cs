using PresentationAPI.Dtos.SocialMediaDto;

namespace PresentationAPI.Services.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task<List<ResultSocialMediaDto>> ListSocialMediaAsync();
        Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto);
        Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto);
        Task DeleteSocialMediaAsync(int id);
        Task<GetSocialMediaDto> GetSocialMediaAsync(int id);
    }
}

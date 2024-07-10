using PresentationUI.Dtos.SubscribeDto;

namespace PresentationUI.Services.SubscribeServices
{
    public interface ISubscribeService
    {
        Task<List<ResultSubscribeDto>> ListSubscribeAsync();
        Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto);
        Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto);
        Task DeleteSubscribeAsync(int id);
        Task<GetSubscribeDto> GetSubscribeAsync(int id);
    }
}

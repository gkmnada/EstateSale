using PresentationUI.Dtos.BottomGridDto;

namespace PresentationUI.Services.BottomGridServices
{
    public interface IBottomGridService
    {
        Task<List<ResultBottomGridDto>> ListBottomGridAsync();
        Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
        Task DeleteBottomGridAsync(int id);
        Task<GetBottomGridDto> GetBottomGridAsync(int id);
    }
}

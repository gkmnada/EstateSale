using PresentationUI.Dtos.ContactDto;

namespace PresentationUI.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> ListContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(int id);
        Task<GetContactDto> GetContactAsync(int id);
        Task<List<ResultContactDto>> ListLastContactAsync();
    }
}

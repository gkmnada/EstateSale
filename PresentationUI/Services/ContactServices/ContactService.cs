using PresentationUI.Dtos.ContactDto;

namespace PresentationUI.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contact", createContactDto);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _httpClient.DeleteAsync("contact?id=" + id);
        }

        public async Task<GetContactDto> GetContactAsync(int id)
        {
            var response = await _httpClient.GetAsync("contact/getcontact?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetContactDto>();
        }

        public async Task<List<ResultContactDto>> ListContactAsync()
        {
            var response = await _httpClient.GetAsync("contact");
            return await response.Content.ReadFromJsonAsync<List<ResultContactDto>>();
        }

        public async Task<List<ResultContactDto>> ListLastContactAsync()
        {
            var response = await _httpClient.GetAsync("contact/listlastcontact");
            return await response.Content.ReadFromJsonAsync<List<ResultContactDto>>();
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("contact", updateContactDto);
        }
    }
}

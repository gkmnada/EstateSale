using PresentationUI.Dtos.EmployeeDto;

namespace PresentationUI.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            await _httpClient.PostAsJsonAsync("employee", createEmployeeDto);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _httpClient.DeleteAsync("employee?id=" + id);
        }

        public async Task<GetEmployeeDto> GetEmployeeAsync(int id)
        {
            var response = await _httpClient.GetAsync("employee/getemployee?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetEmployeeDto>();
        }

        public async Task<List<ResultEmployeeDto>> ListEmployeeAsync()
        {
            var response = await _httpClient.GetAsync("employee");
            return await response.Content.ReadFromJsonAsync<List<ResultEmployeeDto>>();
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            await _httpClient.PutAsJsonAsync("employee", updateEmployeeDto);
        }
    }
}

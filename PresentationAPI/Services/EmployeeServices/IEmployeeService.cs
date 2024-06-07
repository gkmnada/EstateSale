using PresentationAPI.Dtos.EmployeeDto;

namespace PresentationAPI.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<ResultEmployeeDto>> ListEmployeeAsync();
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(int id);
        Task<GetEmployeeDto> GetEmployeeAsync(int id);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.EmployeeDto;
using PresentationAPI.Services.EmployeeServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployee()
        {
            var values = await _employeeService.ListEmployeeAsync();
            return Ok(values);
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var values = await _employeeService.GetEmployeeAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeService.CreateEmployeeAsync(createEmployeeDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeService.UpdateEmployeeAsync(updateEmployeeDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok("Başarılı");
        }
    }
}

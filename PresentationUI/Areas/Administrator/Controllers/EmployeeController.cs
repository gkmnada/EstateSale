using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.EmployeeDto;
using PresentationUI.Services.EmployeeServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.ListEmployeeAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeService.CreateEmployeeAsync(createEmployeeDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Employee", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index", "Employee", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var values = await _employeeService.GetEmployeeAsync(id);

            var employeeViewModel = new EmployeeViewModel
            {
                GetEmployeeDto = values
            };
            return View(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeService.UpdateEmployeeAsync(updateEmployeeDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Employee", new { area = "Administrator" });
            }
            return View();
        }
    }
}

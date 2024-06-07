using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.EmployeeDto;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public EmployeeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Employee");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(employees);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEmployeeDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7071/api/Employee", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7071/api/Employee?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Employee/GetEmployee?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetEmployeeDto>(jsonData);

                var employeeViewModel = new EmployeeViewModel
                {
                    GetEmployeeDto = values
                };
                return View(employeeViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEmployeeDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7071/api/Employee", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Employee", new { area = "Administrator" });
            }
            return View();
        }
    }
}

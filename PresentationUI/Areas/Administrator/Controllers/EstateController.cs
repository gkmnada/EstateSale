using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.CategoryDto;
using PresentationUI.Dtos.EmployeeDto;
using PresentationUI.Dtos.EstateDto;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class EstateController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public EstateController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Estate/ListEstateWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateWithCategoryDto>>(json);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateEstate()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);

                List<SelectListItem> listCategory = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.category_name,
                                                         Value = x.category_id.ToString()
                                                     }).ToList();
                ViewBag.Category = listCategory;
            }

            var response2 = await client.GetAsync("https://localhost:7071/api/Employee");
            if (response2.IsSuccessStatusCode)
            {
                var json = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(json);

                List<SelectListItem> listEmployee = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.name,
                                                         Value = x.employee_id.ToString()
                                                     }).ToList();
                ViewBag.Employee = listEmployee;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateDto createEstateDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createEstateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7071/api/Estate", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteEstate(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7071/api/Estate?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEstate(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Estate/GetEstate?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetEstateDto>(json);

                ViewBag.SelectedCategory = values.category_id.ToString();
                ViewBag.SelectedEmployee = values.employee_id.ToString();
                ViewBag.SelectedSalesType = values.sales_type;

                var responseMessage = await client.GetAsync("https://localhost:7071/api/Category");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> listCategory = (from x in categories
                                                     select new SelectListItem
                                                     {
                                                         Text = x.category_name,
                                                         Value = x.category_id.ToString()
                                                     }).ToList();
                ViewBag.Category = listCategory;

                var responseMessage2 = await client.GetAsync("https://localhost:7071/api/Employee");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData2);

                List<SelectListItem> listEmployee = (from x in employees
                                                     select new SelectListItem
                                                     {
                                                         Text = x.name,
                                                         Value = x.employee_id.ToString()
                                                     }).ToList();
                ViewBag.Employee = listEmployee;

                var estateViewModel = new EstateViewModel
                {
                    GetEstateDto = values
                };
                return View(estateViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEstate(UpdateEstateDto updateEstateDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateEstateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7071/api/Estate", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> ChangeToTrue(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Estate/UpdateDealOfDayChangeToTrue?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> ChangeToFalse(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7071/api/Estate/UpdateDealOfDayChangeToFalse?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }
    }
}

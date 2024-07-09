using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PresentationUI.Dtos.CategoryDto;
using PresentationUI.Dtos.EstateDto;
using PresentationUI.Services;
using System.Text;

namespace PresentationUI.Areas.EstateAgent.Controllers
{
    [Authorize]
    [Area("EstateAgent")]
    public class EstateController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILoginService _loginService;

        public EstateController(IHttpClientFactory clientFactory, ILoginService loginService)
        {
            _clientFactory = clientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/Estate/ListEstateByEstateAgent?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateWithCategoryDto>>(jsonData);
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateDto createEstateDto)
        {
            var id = _loginService.GetUserId;

            createEstateDto.employee_id = int.Parse(id);

            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEstateDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7071/api/Estate", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Estate", new { area = "EstateAgent" });
            }
            else
            {
                return View();
            }
        }
    }
}

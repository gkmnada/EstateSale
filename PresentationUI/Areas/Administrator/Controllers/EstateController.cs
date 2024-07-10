using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.EstateDto;
using PresentationUI.Services.CategoryServices;
using PresentationUI.Services.EmployeeServices;
using PresentationUI.Services.EstateServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly ICategoryService _categoryService;
        private readonly IEmployeeService _employeeService;

        public EstateController(IEstateService estateService, ICategoryService categoryService, IEmployeeService employeeService)
        {
            _estateService = estateService;
            _categoryService = categoryService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _estateService.ListEstateWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEstate()
        {
            var categories = await _categoryService.ListCategoryAsync();

            List<SelectListItem> listCategory = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.category_name,
                                                     Value = x.category_id.ToString()
                                                 }).ToList();
            ViewBag.Category = listCategory;

            var employees = await _employeeService.ListEmployeeAsync();

            List<SelectListItem> listEmployee = (from x in employees
                                                 select new SelectListItem
                                                 {
                                                     Text = x.name,
                                                     Value = x.employee_id.ToString()
                                                 }).ToList();
            ViewBag.Employee = listEmployee;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateDto createEstateDto)
        {
            await _estateService.CreateEstateAsync(createEstateDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteEstate(int id)
        {
            await _estateService.DeleteEstateAsync(id);
            return RedirectToAction("Index", "Estate", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEstate(int id)
        {
            var values = await _estateService.GetEstateAsync(id);

            ViewBag.SelectedCategory = values.category_id.ToString();
            ViewBag.SelectedEmployee = values.employee_id.ToString();
            ViewBag.SelectedSalesType = values.sales_type;

            var categories = await _categoryService.ListCategoryAsync();

            List<SelectListItem> listCategory = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.category_name,
                                                     Value = x.category_id.ToString()
                                                 }).ToList();
            ViewBag.Category = listCategory;

            var employees = await _employeeService.ListEmployeeAsync();

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

        [HttpPost]
        public async Task<IActionResult> UpdateEstate(UpdateEstateDto updateEstateDto)
        {
            await _estateService.UpdateEstateAsync(updateEstateDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Estate", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> ChangeToTrue(int id)
        {
            await _estateService.UpdateDealOfDayChangeToTrueAsync(id);
            return RedirectToAction("Index", "Estate", new { area = "Administrator" });
        }

        public async Task<IActionResult> ChangeToFalse(int id)
        {
            await _estateService.UpdateDealOfDayChangeToFalseAsync(id);
            return RedirectToAction("Index", "Estate", new { area = "Administrator" });
        }
    }
}

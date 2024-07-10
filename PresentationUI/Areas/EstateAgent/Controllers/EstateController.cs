using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Dtos.EstateDto;
using PresentationUI.Services.CategoryServices;
using PresentationUI.Services.EstateServices;
using PresentationUI.Services.LoginServices;

namespace PresentationUI.Areas.EstateAgent.Controllers
{
    [Authorize]
    [Area("EstateAgent")]
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly ILoginService _loginService;
        private readonly ICategoryService _categoryService;

        public EstateController(IEstateService estateService, ILoginService loginService, ICategoryService categoryService)
        {
            _estateService = estateService;
            _loginService = loginService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;

            var values = await _estateService.ListEstateByEstateAgentAsync(int.Parse(id));
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEstate()
        {
            var values = await _categoryService.ListCategoryAsync();

            List<SelectListItem> listCategory = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.category_name,
                                                     Value = x.category_id.ToString()
                                                 }).ToList();
            ViewBag.Category = listCategory;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateDto createEstateDto)
        {
            var id = _loginService.GetUserId;

            createEstateDto.employee_id = int.Parse(id);

            await _estateService.CreateEstateAsync(createEstateDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Estate", new { area = "EstateAgent" });
            }

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
using PresentationUI.Dtos.TestimonialDto;
using PresentationUI.Services.TestimonialServices;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.ListTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonialAsync(createTestimonialDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("Index", "Testimonial", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _testimonialService.GetTestimonialAsync(id);

            var testimonialViewModel = new TestimonialViewModel
            {
                GetTestimonialDto = values
            };
            return View(testimonialViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Administrator" });
            }
            return View();
        }
    }
}


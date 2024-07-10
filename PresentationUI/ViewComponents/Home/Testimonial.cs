using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.TestimonialServices;

namespace PresentationUI.ViewComponents.Home
{
    public class Testimonial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public Testimonial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.ListTestimonialAsync();
            return View(values);
        }
    }
}

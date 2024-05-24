using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.AboutDto;
using PresentationAPI.Services.AboutServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAbout()
        {
            var values = await _aboutService.ListAboutAsync();
            return Ok(values);
        }

        [HttpGet("GetAbout")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _aboutService.GetAboutAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Başarılı");
        }
    }
}

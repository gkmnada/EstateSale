using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.SocialMediaDto;
using PresentationAPI.Services.SocialMediaServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListSocialMedia()
        {
            var values = await _socialMediaService.ListSocialMediaAsync();
            return Ok(values);
        }

        [HttpGet("GetSocialMedia")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _socialMediaService.GetSocialMediaAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _socialMediaService.CreateSocialMediaAsync(createSocialMediaDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.UpdateSocialMediaAsync(updateSocialMediaDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            return Ok("Başarılı");
        }
    }
}

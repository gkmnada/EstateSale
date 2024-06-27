using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.PopularLocationDto;
using PresentationAPI.Services.PopularLocationServices;

namespace PresentationAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationController : ControllerBase
    {
        private readonly IPopularLocationService _popularLocationService;

        public PopularLocationController(IPopularLocationService popularLocationService)
        {
            _popularLocationService = popularLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> ListPopularLocation()
        {
            var values = await _popularLocationService.ListPopularLocationAsync();
            return Ok(values);
        }

        [HttpGet("GetPopularLocation")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _popularLocationService.GetPopularLocationsAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _popularLocationService.CreatePopularLocationAsync(createPopularLocationDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _popularLocationService.UpdatePopularLocationAsync(updatePopularLocationDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _popularLocationService.DeletePopularLocationAsync(id);
            return Ok("Başarılı");
        }
    }
}

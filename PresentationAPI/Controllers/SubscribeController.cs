using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.SubscribeDto;
using PresentationAPI.Services.SubscribeServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListSubscribe()
        {
            var values = await _subscribeService.ListSubscribeAsync();
            return Ok(values);
        }

        [HttpGet("GetSubscribe")]
        public async Task<IActionResult> GetSubscribe(int id)
        {
            var value = await _subscribeService.GetSubscribeAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            await _subscribeService.CreateSubscribeAsync(createSubscribeDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            await _subscribeService.UpdateSubscribeAsync(updateSubscribeDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            await _subscribeService.DeleteSubscribeAsync(id);
            return Ok("Başarılı");
        }
    }
}

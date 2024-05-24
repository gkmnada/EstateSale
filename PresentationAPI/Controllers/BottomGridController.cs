using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.BottomGridDto;
using PresentationAPI.Services.BottomGridServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridService _bottomGridService;

        public BottomGridController(IBottomGridService bottomGridService)
        {
            _bottomGridService = bottomGridService;
        }

        [HttpGet]
        public async Task<IActionResult> ListBottomGrid()
        {
            var values = await _bottomGridService.ListBottomGridAsync();
            return Ok(values);
        }

        [HttpGet("GetBottomGrid")]
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridService.GetBottomGridAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridService.CreateBottomGridAsync(createBottomGridDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridService.UpdateBottomGridAsync(updateBottomGridDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridService.DeleteBottomGridAsync(id);
            return Ok("Başarılı");
        }
    }
}

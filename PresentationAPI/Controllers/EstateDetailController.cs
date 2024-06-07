using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.EstateDetailDto;
using PresentationAPI.Services.EstateDetailServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateDetailController : ControllerBase
    {
        private readonly IEstateDetailService _estateDetailService;

        public EstateDetailController(IEstateDetailService estateDetailService)
        {
            _estateDetailService = estateDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ListEstateDetail()
        {
            var values = await _estateDetailService.ListEstateDetailAsync();
            return Ok(values);
        }

        [HttpGet("GetEstateDetail")]
        public async Task<IActionResult> GetEstateDetail(int id)
        {
            var value = await _estateDetailService.GetEstateDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstateDetail(CreateEstateDetailDto createEstateDetailDto)
        {
            await _estateDetailService.CreateEstateDetailAsync(createEstateDetailDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEstateDetail(UpdateEstateDetailDto updateEstateDetailDto)
        {
            await _estateDetailService.UpdateEstateDetailAsync(updateEstateDetailDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEstateDetail(int id)
        {
            await _estateDetailService.DeleteEstateDetailAsync(id);
            return Ok("Başarılı");
        }
    }
}

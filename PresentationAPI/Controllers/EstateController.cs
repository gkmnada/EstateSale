using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.EstateDto;
using PresentationAPI.Services.EstateServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        [HttpGet]
        public async Task<IActionResult> ListEstate()
        {
            var values = await _estateService.ListEstateAsync();
            return Ok(values);
        }

        [HttpGet("GetEstate")]
        public async Task<IActionResult> GetEstate(int id)
        {
            var value = await _estateService.GetEstateAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateDto createEstateDto)
        {
            await _estateService.CreateEstateAsync(createEstateDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEstate(UpdateEstateDto updateEstateDto)
        {
            await _estateService.UpdateEstateAsync(updateEstateDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            await _estateService.DeleteEstateAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("ListEstateWithCategory")]
        public async Task<IActionResult> ListEstateWithCategory()
        {
            var values = await _estateService.ListEstateWithCategoryAsync();
            return Ok(values);
        }
    }
}

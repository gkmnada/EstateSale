using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Services.StatisticServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var value = await _statisticService.GetCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("GetInactiveCategoryCount")]
        public async Task<IActionResult> GetInactiveCategoryCount()
        {
            var value = await _statisticService.GetInactiveCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("GetActiveCategoryCount")]
        public async Task<IActionResult> GetActiveCategoryCount()
        {
            var value = await _statisticService.GetActiveCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("GetEstateCount")]
        public async Task<IActionResult> GetEstateCount()
        {
            var value = await _statisticService.GetEstateCountAsync();
            return Ok(value);
        }

        [HttpGet("GetCategoryByMaxEstateCount")]
        public async Task<IActionResult> GetCategoryByMaxEstateCount()
        {
            var value = await _statisticService.GetCategoryByMaxEstateCountAsync();
            return Ok(value);
        }

        [HttpGet("GetAverageEstatePriceByRent")]
        public async Task<IActionResult> GetAverageEstatePriceByRent()
        {
            var value = await _statisticService.GetAverageEstatePriceByRentAsync();
            return Ok(value);
        }

        [HttpGet("GetAverageEstatePriceBySale")]
        public async Task<IActionResult> GetAverageEstatePriceBySale()
        {
            var value = await _statisticService.GetAverageEstatePriceBySaleAsync();
            return Ok(value);
        }

        [HttpGet("GetCityByMaxEstateCount")]
        public async Task<IActionResult> GetCityByMaxEstateCount()
        {
            var value = await _statisticService.GetCityByMaxEstateCountAsync();
            return Ok(value);
        }

        [HttpGet("GetNewestBuildingYear")]
        public async Task<IActionResult> GetNewestBuildingYear()
        {
            var value = await _statisticService.GetNewestBuildingYearAsync();
            return Ok(value);
        }

        [HttpGet("GetOldestBuildingYear")]
        public async Task<IActionResult> GetOldestBuildingYear()
        {
            var value = await _statisticService.GetOldestBuildingYearAsync();
            return Ok(value);
        }
    }
}

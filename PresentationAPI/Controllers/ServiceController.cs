using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.ServiceDto;
using PresentationAPI.Services.ServiceServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> ListService()
        {
            var values = await _serviceService.ListServiceAsync();
            return Ok(values);
        }

        [HttpGet("GetService")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _serviceService.GetServiceAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceService.CreateServiceAsync(createServiceDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceService.UpdateServiceAsync(updateServiceDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return Ok("Başarılı");
        }
    }
}

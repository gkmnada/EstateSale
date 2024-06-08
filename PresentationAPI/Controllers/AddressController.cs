using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.AddressDto;
using PresentationAPI.Services.AddressServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAddress()
        {
            var values = await _addressService.ListAddressAsync();
            return Ok(values);
        }

        [HttpGet("GetAddress")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var value = await _addressService.GetAddressAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
        {
            await _addressService.CreateAddressAsync(createAddressDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            await _addressService.UpdateAddressAsync(updateAddressDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return Ok("Başarılı");
        }
    }
}

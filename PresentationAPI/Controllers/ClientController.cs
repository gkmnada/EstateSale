using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.ClientDto;
using PresentationAPI.Services.ClientServices;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> ListClient()
        {
            var values = await _clientService.ListClientAsync();
            return Ok(values);
        }

        [HttpGet("GetClient")]
        public async Task<IActionResult> GetClient(int id)
        {
            var value = await _clientService.GetClientAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDto createClientDto)
        {
            await _clientService.CreateClientAsync(createClientDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClientDto updateClientDto)
        {
            await _clientService.UpdateClientAsync(updateClientDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientAsync(id);
            return Ok("Başarılı");
        }
    }
}

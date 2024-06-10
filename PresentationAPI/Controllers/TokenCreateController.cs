using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Dtos.AppUserDto;
using PresentationAPI.Tools;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken(GetCheckAppUserDto getCheckAppUserDto)
        {
            var values = JwtTokenGenerator.GenerateToken(getCheckAppUserDto);
            return Ok(values);
        }
    }
}

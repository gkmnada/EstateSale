using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationAPI.Context;
using PresentationAPI.Dtos.AppUserDto;
using PresentationAPI.Dtos.LoginDto;
using PresentationAPI.Tools;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DapperContext _dapperContext;

        public LoginController(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "select * from app_user where username = @username and password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", createLoginDto.username);
            parameters.Add("@password", createLoginDto.password);
            using (var connection = _dapperContext.CreateConnection())
            {
                var login = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var values = await connection.QueryFirstOrDefaultAsync<ResultLoginDto>(query, parameters);

                if (login != null)
                {
                    GetCheckAppUserDto model = new GetCheckAppUserDto();
                    model.Id = values.app_user_id;
                    model.Username = login.username;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
                }
            }
        }
    }
}

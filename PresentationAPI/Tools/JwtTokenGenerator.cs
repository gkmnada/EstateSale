using Microsoft.IdentityModel.Tokens;
using PresentationAPI.Dtos.AppUserDto;
using PresentationAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PresentationAPI.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserDto getCheckAppUserDto)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(getCheckAppUserDto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, getCheckAppUserDto.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserDto.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(getCheckAppUserDto.Username))
            {
                claims.Add(new Claim("Username", getCheckAppUserDto.Username));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.Now.AddMinutes(JwtTokenDefaults.ExpiresInMinutes);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                expires: expireDate,
                signingCredentials: credentials,
                notBefore: DateTime.UtcNow
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }
    }
}

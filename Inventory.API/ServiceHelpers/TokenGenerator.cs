using Inventory.Data.Entities;
using Inventory.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory.API.ServiceHelpers
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("ThisKeyNeedsToBeLongAndSecretDuringALiveEnviroment");

            var claims = new List<Claim> { 
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Username),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new("userid", user.Id.ToString())
            };

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromHours(8)),
                Issuer = "https://id.inventory.xenor",
                Audience = "https://id.inventory.xenor",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDiscriptor);

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}

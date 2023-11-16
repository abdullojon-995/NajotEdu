using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NajotTalim.Domain.Entities;
using NajotTalim.Infrastructure.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace NajotTalim.Infrastructure.Services
{
    public class JWTToken : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JWTToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateAccessToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString()),
                new Claim("Role",user.Role.ToString())
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(
                                                      Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                                                      SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                            _configuration["JWT:Issuer"],
                            _configuration["JWT:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}

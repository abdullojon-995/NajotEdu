using Microsoft.AspNetCore.Http;
using NajotTalim.Application.Abstractions;
using System.IdentityModel.Tokens.Jwt;

namespace NajotTalim.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            var userClaims = contextAccessor.HttpContext!.User.Claims;

            var idClaim = userClaims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Name);

            if (idClaim != null && int.TryParse(idClaim.Value, out int value))
            {
                UserId = value;
            }
        }
    }
}

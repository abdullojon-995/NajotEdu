using NajotTalim.Domain.Entities;

namespace NajotTalim.Infrastructure.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}

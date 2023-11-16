using Microsoft.EntityFrameworkCore;
using NajotTalim.Infrastructure.Abstractions;
using NajotTalim.Infrastructure.HashGenerator;
using NajotTalim.Infrastructure.Persistence;

namespace NajotTalim.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(ApplicationDbContext context,
            ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.PasswordHash != GenerateHash.GetHash(password))
            {
                throw new Exception("Password is wrong");
            }

            return _tokenService.GenerateAccessToken(user);
        }
    }
}

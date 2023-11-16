using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NajotTalim.Api.Models;
using NajotTalim.Infrastructure.Abstractions;

namespace NajotTalim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
           var token =  await _authService.LoginAsync(loginRequest.UserName,loginRequest.Password);

            return Ok(token);
        }
    }
}

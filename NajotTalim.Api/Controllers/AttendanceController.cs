using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Models;

namespace NajotTalim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("check")]
        public async Task<IActionResult> AttendanceCheck(DoAttendanceCheckModel model)
        {
            await _attendanceService.ChecksAsync(model);

            return Ok();
        }
    }
}

using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface IAttendanceService
    {
        Task ChecksAsync(DoAttendanceCheckModel model);
    }
}

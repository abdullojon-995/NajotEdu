using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherViewModel> GetByIdAsync(int id);
        Task<List<TeacherViewModel>> GetAllAsync();
        Task CreateAsync(CreateTeacherModel model);
        Task UpdateAsync(UpdateTeacherModel model);
        Task DeleteAsync(int id);
    }
}

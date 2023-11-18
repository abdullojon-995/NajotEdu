using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface IStudentService
    {
        Task<StudentViewModel> GetByIdAsync(int id);
        Task<List<StudentViewModel>> GetAllAsync();
        Task CreateAsync(CreateStudentModel model);
        Task UpdateAsync(UpdateStudentModel model);
        Task DeleteAsync(int id);
    }
}

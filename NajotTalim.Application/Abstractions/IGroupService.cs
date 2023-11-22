using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface IGroupService : ICrudService<int, GroupViewModel, CreateGroupModel, UpdateGroupModel>
    {
        Task<List<LessonViewModel>> GetLessonsAsync(int groupId);
        Task AddStudentAsync(AddStudentGroupModel model, int groupId);
        Task RemoveStudentAsync(int studentId, int groupId);
    }
}

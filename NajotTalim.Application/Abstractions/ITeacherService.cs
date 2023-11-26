using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface ITeacherService : ICrudService<int, TeacherViewModel, CreateTeacherModel, UpdateTeacherModel>
    {
    }
}

using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface IStudentService : ICrudService<int, StudentViewModel, CreateStudentModel, UpdateStudentModel>
    {
    }
}

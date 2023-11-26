using AutoMapper;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Models;
using NajotTalim.Domain.Entities;
using NajotTalim.Domain.Enums;

namespace NajotTalim.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IHashProvider hashProvider)
        {
            CreateMap<User, TeacherViewModel>();

            CreateMap<CreateTeacherModel, User>()
                .ForMember(d => d.Role, o => o.MapFrom(s => UserRole.Teacher))
                .ForMember(x => x.PasswordHash, o => o.MapFrom(p => hashProvider.GetHash(p.Password)));

            CreateMap<UpdateTeacherModel, User>()
                .BeforeMap((model, entity) =>
                {
                    entity.PasswordHash = model.Password == null
                        ? entity.PasswordHash
                        : hashProvider.GetHash(model.Password);
                });
        }
    }
}

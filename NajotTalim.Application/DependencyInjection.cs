using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.MappingProfiles;
using NajotTalim.Application.Services;

namespace NajotTalim.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSingleton(provider => new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile(provider.GetRequiredService<IHashProvider>()));
            }).CreateMapper());
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddHostedService<LessonStatusCheckService>();

            return services;
        }
    }
}
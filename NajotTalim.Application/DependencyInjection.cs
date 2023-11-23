using Microsoft.Extensions.DependencyInjection;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Services;

namespace NajotTalim.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IProfileService,ProfileService>();

            return services;
        }
    }
}
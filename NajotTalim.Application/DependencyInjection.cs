using Microsoft.Extensions.DependencyInjection;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Services;

namespace NajotTalim.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService,TeacherService>();
            services.AddScoped<IStudentService,StudentService>();

            return services;
        }
    }
}
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Services;
using NajotTalim.Domain.Enums;
using NajotTalim.Infrastructure.Abstractions;
using NajotTalim.Infrastructure.HashGenerators;
using NajotTalim.Infrastructure.Persistence;
using NajotTalim.Infrastructure.Services;
using System.Text;

namespace NajotTalim.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITokenService, JWTToken>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHashProvider, HashProvider>();
            services.AddScoped<IFileService, FileService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["JWT:Issuer"],
                            ValidAudience = configuration["JWT:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim("Role", UserRole.Admin.ToString());
                });
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
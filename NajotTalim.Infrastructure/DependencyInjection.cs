using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NajotTalim.Domain.Enums;
using NajotTalim.Infrastructure.Abstractions;
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

            services.AddScoped<ITokenService, JWTToken>();
            services.AddScoped<IAuthService, AuthService>();

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

            return services;
        }
    }
}
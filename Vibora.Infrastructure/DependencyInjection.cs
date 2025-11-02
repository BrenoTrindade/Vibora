using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Vibora.Application.Common.Interfaces;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;
using Vibora.Infrastructure.Repositories;
using Vibora.Infrastructure.Services;
using Vibora.Infrastructure.Settings;

namespace Vibora.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerOptionsSetup>();

            services.AddJwtAuthentication(configuration);

            services.AddPersistence(configuration);

            services.AddScoped<IPasswordHasherService, PasswordHasherService>();

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
        private static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ViboraDb");
            services.AddDbContext<ViboraDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddScoped<ITrackRepository, TrackRepository>();

            return services;
        }

        private static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer()
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            });

            services.AddAuthorization();

            return services;
        }
    }
}


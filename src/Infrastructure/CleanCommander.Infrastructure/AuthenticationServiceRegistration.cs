using CleanCommander.Application.Contracts.Authentication;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Infrastructure.Identity.Persistence;
using CleanCommander.Infrastructure.Identity.Repositories;
using CleanCommander.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Infrastructure.Identity
{
    public static class AuthenticationServiceRegistration
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CleanCommanderConnectionString")));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        /// <summary>
        /// This is used in the SQL Server docker container, which is created in docker-compose.
        /// Everytime a new SQL Server docker container is created, we need to run EF migrations.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RunAuthenticationMigrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:CleanCommanderConnectionString"]));

            using var serviceProvider = services.BuildServiceProvider();
            using var dbContext = serviceProvider.GetRequiredService<AuthenticationDbContext>();

            try
            {
                dbContext.Database.Migrate();
                Console.WriteLine($"Migrations applied perfectly!");
            }
            catch (Exception ex)
            {
                // Handle migration errors
                Console.WriteLine($"Error applying migrations: {ex.Message}");
                throw;
            }
        }
    }
}

using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Persistence;
using CleanCommander.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace CleanCommander.Persistence
{
    /// <summary>
    /// This class extends the service collection, which is normally found in the Startup.cs class. This class is not available here, since we
    /// are doing clean architecture. This is for service registration. Here, we add support for dependency injection. We also add the DbContext, 
    /// and specify that we will use SqlServer. Finally, the connectionstring is registered.
    /// 
    /// These registrations are made here since PersistenceServiceRegistration is part of infrastructure. The interfaces that are implemented via DI, exist in the 
    /// Core/Application, and if this file were there, then Core/Application would have to reference infrastructure, which would violate clean architecture.
    /// </summary>
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new StringBuilder (configuration["ConnectionStrings:CleanCommanderConnectionString"]);
            string conn = config.Replace("ENVPW", configuration["DB_PW"])
                                .ToString();

            services.AddDbContext<CleanCommanderDbContext>(options => options.UseSqlServer(conn));

            //services.AddDbContext<CleanCommanderDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("CleanCommanderConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();

            return services;
        }

        /// <summary>
        /// This is used in the SQL Server docker container, which is created in docker-compose.
        /// Everytime a new SQL Server docker container is created, we need to run EF migrations.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RunMigrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanCommanderDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:CleanCommanderConnectionString"]));

            using var serviceProvider = services.BuildServiceProvider();
            using var dbContext = serviceProvider.GetRequiredService<CleanCommanderDbContext>();

            try
            {
                dbContext.Database.Migrate();
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
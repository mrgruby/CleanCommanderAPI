using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application
{
    /// <summary>
    /// This class adds support for Dependency Injection in this class library.
    /// This class extends the service collection, which is normally found in the Startup.cs class. Startup.cs is not available here, since we
    /// are doing clean architecture, so AutoMapper and MediateR, which are both used in the Application project, must be registered this way
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}

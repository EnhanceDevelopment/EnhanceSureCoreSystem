using EnhanceSure.Application.Features.Interviewees.Handler.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Net.WebSockets;
using System.Reflection;

namespace EnhanceSure.Application {
    public static class DependencyResolver {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            //// Register AutoMapper and MediatR for the correct assembly
            services.AddAutoMapper(executingAssembly);        //for all executing Assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));              // for MediatR V>V12.0


            //var intermediateServiceProvider = services.BuildServiceProvider();
            //var configService = intermediateServiceProvider.GetService<IConfigurationService>();
            //var configuration = configService?.GetConfiguration();
            //services.ConfigureDatabase(configuration);

            return services;
        }
    }
}

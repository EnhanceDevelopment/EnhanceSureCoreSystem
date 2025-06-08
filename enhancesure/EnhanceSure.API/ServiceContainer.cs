using EnhanceSure.API.Common.Configuration;
using EnhanceSure.API.OptionSetup;
using EnhanceSure.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EnhanceSure.API {
    public static class ServiceContainer {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            services.ConfigureInfrastructureServices();
            services.ConfigureOptions<JwtOptionSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer();

            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
                (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = Directory.GetCurrentDirectory()
                });

            return services;
        }
    }
}

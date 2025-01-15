using EnhanceSure.API.OptionSetup;
using EnhanceSure.Application.Contracts.Infrastructure.Authentication;
using EnhanceSure.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EnhanceSure.Infrastructure;

namespace EnhanceSure.API {
    public static class ServiceContainer {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            services.ConfigureInfrastructureServices();
            services.ConfigureOptions<JwtOptionSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer();

            return services;
        }
    }
}

using EnhanceSure.Application.Contracts.Infrastructure.Authentication;
using EnhanceSure.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnhanceSure.Infrastructure {
    public static class DependencyResolver {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}

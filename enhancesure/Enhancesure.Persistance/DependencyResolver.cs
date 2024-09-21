using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Domain.Interfaces.Common;
using EnhanceSure.Persistance.Connections;
using EnhanceSure.Persistance.Constants;
using EnhanceSure.Persistance.DbContexts;
using EnhanceSure.Persistance.Repositories;
using EnhanceSure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnhanceSure.Persistance {
    public static class DependencyResolver {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DbConnectionConstants.ConnectionStringName);

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            );

            services.AddTransient<IDbConnectionFactory>(provider => { return new DbConnectionFactory(configuration); });
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped(typeof(IVirtualRepositoryAsync<>), typeof(VirtualRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIntervieweeRepository, IntervieweeRepository>();
            services.AddScoped<IInterviewerRepository, InterviewerRepository>();
            return services;
        }
    }
}

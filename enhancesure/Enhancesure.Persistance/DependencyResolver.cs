using Domain.Interfaces;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.Contracts.Persistances.Common;
using EnhanceSure.Application.Contracts.Persistances.DbContext;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Persistance.Connections;
using EnhanceSure.Persistance.Constants;
using EnhanceSure.Persistance.DbContexts;
using EnhanceSure.Persistance.Repositories;
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
            //services.AddTransient<IDbConnectionFactory>(provider => { return new DbConnectionFactory(configuration); });
            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            //services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IIntervieweeRepository, IntervieweeRepository>();
            services.AddScoped<IInterviewerRepository, InterviewerRepository>();
            return services;
        }
    }
}

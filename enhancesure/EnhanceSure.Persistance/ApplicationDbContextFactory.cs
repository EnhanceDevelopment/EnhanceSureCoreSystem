using EnhanceSure.API.Common.Configuration;
using EnhanceSure.Persistance.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace EnhanceSure.Persistance {
    public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext> {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //var environment = ParseEnvironment(args);
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //var connectionString = configuration.GetConnectionString(Constants.DbConnectionConstants.ConnectionStringName);
            //builder.UseSqlServer(connectionString);
            //return new ApplicationDbContext(builder.Options);


            var environment = ParseEnvironment(args);
            Console.WriteLine($"environment - {environment}");

            var environmentService = new EnvironmentService(environment);
            var configurationService = new ConfigurationService(environmentService);
            Console.WriteLine($"directory - {Directory.GetCurrentDirectory()}");
            var connectionString = configurationService.GetConfiguration(Directory.GetCurrentDirectory()).GetConnectionString(Constants.DbConnectionConstants.ConnectionStringName);
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);

        }
        private string ParseEnvironment(string[] args)
        {
            var regex = new Regex(@"--environment \w+");
            var arguments = string.Join(" ", args);

            var match = regex.Match(arguments);

            if(match.Success)
            {
                var splitted = match.Value.Split(' ');

                if(splitted.Length > 1)
                {
                    return splitted[1];
                }
            }

            return "Dev";
        }
    }
}

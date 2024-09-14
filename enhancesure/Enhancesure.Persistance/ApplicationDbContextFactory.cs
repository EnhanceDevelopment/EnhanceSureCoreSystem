using EnhanceSure.Persistance.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace EnhanceSure.Persistance {
    public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext> {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString(Constants.DbConnectionConstants.ConnectionStringName);
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

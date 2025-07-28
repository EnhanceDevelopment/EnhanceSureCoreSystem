using EnhanceSure.Persistance.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EnhanceSure.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            var maxRetries = 10;
            var delay = TimeSpan.FromSeconds(5);

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    using IServiceScope scope = app.ApplicationServices.CreateScope();
                    using ApplicationDbContext dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    dbContext.Database.Migrate();

                    Console.WriteLine("Database migration successful.");
                    break;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Attempt {attempt}: Database connection failed - {ex.Message}");

                    if (attempt == maxRetries)
                    {
                        Console.WriteLine("Max retries reached. Exiting...");
                        throw;
                    }

                    Thread.Sleep(delay);
                }
            }
        }
    }
}

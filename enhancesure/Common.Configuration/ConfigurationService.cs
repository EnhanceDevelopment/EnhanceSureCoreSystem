using Microsoft.Extensions.Configuration;

namespace EnhanceSure.API.Common.Configuration
{
    public class ConfigurationService:IConfigurationService
    {
        public IEnvironmentService EnvService { get; }
        public string CurrentDirectory { get; set; }

        public string DefaultConfigurationFile = "appsettings.json";
        public string OverriddenConfigurationFile => $"appsettings.{EnvService.EnvironmentName}.json";

        public ConfigurationService(IEnvironmentService envService)
        {
            EnvService = envService;
        }

        public IConfiguration GetConfiguration(string directory)
        {
            CurrentDirectory ??= directory;
            return new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile(DefaultConfigurationFile, optional: false, reloadOnChange: true)
                .AddJsonFile(OverriddenConfigurationFile, optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        IConfiguration IConfigurationService.GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}

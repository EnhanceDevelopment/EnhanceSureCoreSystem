using Microsoft.Extensions.Configuration;

namespace EnhanceSure.API.Common.Configuration
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}

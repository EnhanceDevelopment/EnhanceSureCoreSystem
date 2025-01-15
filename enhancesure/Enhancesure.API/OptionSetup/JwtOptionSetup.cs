using EnhanceSure.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace EnhanceSure.API.OptionSetup {
    public class JwtOptionSetup: IConfigureOptions<JwtOptions> {
        private readonly string SectionName ="JwtSetup";
        private readonly IConfiguration _configuration;
        public JwtOptionSetup(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}

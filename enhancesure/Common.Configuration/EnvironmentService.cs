namespace EnhanceSure.API.Common.Configuration
{
    public class EnvironmentService:IEnvironmentService
    {
        public string EnvironmentName { get; set; }
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AspNetCoreEnvironment) ?? Constants.Environments.Production;
        }

        public EnvironmentService(string name)
        {
            EnvironmentName = name;
        }
    }
}

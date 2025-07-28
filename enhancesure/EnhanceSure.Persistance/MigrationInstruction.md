# 🌟 EF Core Migrations - Multi-Environment Setup

A guide to managing database migrations across Development, UAT, and Production environments.

## 🛠️ Prerequisites
- .NET Core SDK installed
- EF Core tools (`dotnet tool install --global dotnet-ef`)
- Access to all environment databases
- Environment-specific connection strings



## Migration Method 1:
### Setting value for ASPNETCORE_ENVIRONMENT variable to load appropriate appsettings.{Environment}.json

***For Windows powershell***<br>
-> $env:ASPNETCORE_ENVIRONMENT = "dev"<br>
-> dotnet ef database update



***For Linux***  (run on bash for window machine)<br>
-> export ASPNETCORE_ENVIRONMENT=dev<br>
-> dotnet ef database update


After setting the environment run the migration commands and after migration set the environment back to the "Dev"
for example (window machine):<br>
-> $env:ASPNETCORE_ENVIRONMENT = "uat"<br>
-> add-migration 'example migration'<br>
-> update-database

$env:ASPNETCORE_ENVIRONMENT = "dev"



## Migration Method 2
change the environment variable in ConfigurationService.cs file

    public string OverriddenConfigurationFile => $"appsettings.{EnvService.EnvironmentName}.json";

    you can change as following 
    {EnvService.EnvironmentName} ===> {Constants.Environments.UserAcceptanceTest} for uat environment   and 
    {EnvService.EnvironmentName} ===> {Constants.Environments.Production} for production database environment

Then, execute your migration commands.
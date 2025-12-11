using EnhanceSure.API;
using EnhanceSure.API.Extensions;
using EnhanceSure.Application;
using EnhanceSure.Persistance;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .ConfigureApplicationServices()
    .ConfigureApiServices()
    .ConfigurePersistenceServices(builder.Configuration)
    .AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version="v1",
        Title="EnhanceSure API",
        Description="Contains the API endpoints for EnhanceSure",
        //TermsOfService=new Uri("https://example.com/terms"),
        //Contact=new OpenApiContact
        //{
        //    Name="Example Contact",
        //    Url=new Uri("https://example.com/contact")
        //},
        //License=new OpenApiLicense
        //{
        //    Name="Example License",
        //    Url=new Uri("https://example.com/license")
        //}
    });
    options.AddSecurityDefinition("Bearer ", new OpenApiSecurityScheme
    {
        Name="EnhanceSure",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer",
                            }
                        },Array.Empty<string>()
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.ApplyMigrations();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

using Sgpa.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

builder.Configuration
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

builder.Services.AddApiConfiguration(configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();
app.Run();

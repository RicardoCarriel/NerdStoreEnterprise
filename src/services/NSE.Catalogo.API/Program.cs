using NSE.Catalogo.API.Configuration;
using NSE.WebApi.Core.Identidade;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
 .SetBasePath(builder.Environment.ContentRootPath)
 .AddJsonFile("appsettings.json", true, true)
 .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
 .AddEnvironmentVariables();

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(builder.Environment);

app.Run();

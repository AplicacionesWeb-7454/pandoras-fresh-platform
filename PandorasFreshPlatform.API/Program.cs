using Microsoft.EntityFrameworkCore;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Pandoras Fresh Platform API",
        Version = "v1",
        Description = "API para gestión de sensores"
    });
});

// Aquí puedes agregar otros servicios si los necesitas
// builder.Services.AddScoped<IMiServicio, MiServicio>();

var app = builder.Build();

// Configure the HTTP middleware pipeline.

// Redirección automática a Swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

// Habilitar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pandoras Fresh Platform API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
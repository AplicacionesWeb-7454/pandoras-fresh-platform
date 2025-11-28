using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using PandorasFreshPlatform.API.Reports.Application.Internal.CommandServices;
using PandorasFreshPlatform.API.Reports.Application.Internal.QueryServices;
using PandorasFreshPlatform.API.Reports.Application.Internal.Services;
using PandorasFreshPlatform.API.Reports.Domain.Repositories;
using PandorasFreshPlatform.API.Reports.Domain.Services;
using PandorasFreshPlatform.API.Reports.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);
// 🔧 Forzar carga explícita de configuración por entorno
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en", "es", "es-PE" };
    var cultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

// ✅ Add Database Connection (simplificado con appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Console.WriteLine($"[DEBUG] Environment: {builder.Environment.EnvironmentName}");
    Console.WriteLine($"[DEBUG] Connection string: {builder.Configuration.GetConnectionString("DefaultConnection")}");

    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});

// Bounded Contexts Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReportWriteRepository, ReportWriteRepository>();
builder.Services.AddScoped<GenerateInventoryReportCommandService>();
builder.Services.AddScoped<GetDashboardMetricsQueryService>();
builder.Services.AddScoped<IReportBuilderService, ReportBuilderService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();

var locOptions = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

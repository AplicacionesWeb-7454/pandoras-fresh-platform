using CatchUpPlatform.API.Reports.Application.Internal.CommandServices.Handlers;
using Microsoft.EntityFrameworkCore;
using pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pandoraFr.API.Shared.Domain.Repositories;
using pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Repositories;

using pandoraFr.API.Reports.Domain.Repositories;
using pandoraFr.API.Reports.Domain.Services;
using pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Repositories;

using pandoraFr.API.Reports.Application.Internal.CommandServices.Handlers;
using pandoraFr.API.Reports.Application.Internal.QueryServices.Handlers;
using pandoraFr.API.Reports.Domain.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Configuración de EF Core con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 40))
    ));

// 🧩 Repositorios compartidos
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 📦 Repositorios específicos de Reports
builder.Services.AddScoped<IInventoryReadRepository, InventoryReadRepository>();
builder.Services.AddScoped<ILossesReadRepository, LossesReadRepository>();
builder.Services.AddScoped<IReportWriteRepository, ReportWriteRepository>();

// 🛠️ Servicios de dominio
builder.Services.AddScoped<IReportBuilderService, ReportBuilderService>();
builder.Services.AddScoped<IReportExportService, ReportExportService>();
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

// 🧠 Handlers de comandos y queries
builder.Services.AddScoped<GenerateInventoryReportCommandHandler>();
builder.Services.AddScoped<GenerateLossesReportCommandHandler>();
builder.Services.AddScoped<ExportReportCommandHandler>();
builder.Services.AddScoped<ShareReportCommandHandler>();
builder.Services.AddScoped<GetDashboardMetricsQueryHandler>();

// 📖 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Controladores
builder.Services.AddControllers();

var app = builder.Build();

// ✅ Middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PandoraFr API v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz: http://localhost:5000
    });
}

// Middleware y endpoints
app.MapControllers();
app.Run();

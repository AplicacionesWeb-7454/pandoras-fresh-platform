using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection (OPCIONAL)
bool isDatabaseConfigured = false;

if (builder.Environment.IsDevelopment())
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var password = builder.Configuration["DbPassword"];
    
    // Solo configurar la base de datos si hay connection string y password
    if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(password))
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var completeConnectionString = $"{connectionString}password={password};";
            
            options.UseMySQL(completeConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        
        isDatabaseConfigured = true;
        Console.WriteLine("✅ Database configured successfully.");
    }
    else
    {
        Console.WriteLine("⚠️ Database configuration not found. Running without database.");
    }
}

// Bounded Contexts Dependency Injection
// Shared Context Dependency Injection - SOLO SI HAY BASE DE DATOS
if (isDatabaseConfigured)
{
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}

// News Context Dependency Injection


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // REDIRIGIR A SWAGGER AL ABRIR EL NAVEGADOR - DEBE IR ANTES DE SWAGGER
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });
    
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Crear la base de datos solo si está configurada
if (isDatabaseConfigured)
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    if (dbContext != null)
    {
        try
        {
            dbContext.Database.EnsureCreated();
            Console.WriteLine("✅ Database initialized successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Could not initialize database: {ex.Message}");
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
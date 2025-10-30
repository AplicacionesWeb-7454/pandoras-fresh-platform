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

// Add Database Connection
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString)) throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            var password = builder.Configuration["DbPassword"];
            if (string.IsNullOrEmpty(password))
                throw new InvalidOperationException("Database password not found in user secrets.");
            
            // Build the complete connection string
            var completeConnectionString = $"{connectionString}password={password};";
            
            options.UseMySQL(completeConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });

// Bounded Contexts Dependency Injection
// Shared Context Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Context Dependency Injection


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
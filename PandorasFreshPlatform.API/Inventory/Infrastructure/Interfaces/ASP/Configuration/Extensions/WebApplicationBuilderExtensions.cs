using PandorasFreshPlatform.API.Inventory.Application.Internal.CommandServices;
using PandorasFreshPlatform.API.Inventory.Application.Internal.EventHandlers;
using PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddInventoryContextServices(this WebApplicationBuilder builder)
    {
        // Register repositories
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
        builder.Services.AddScoped<IStorageBoxRepository, StorageBoxRepository>();
        builder.Services.AddScoped<IProductInstanceRepository, ProductInstanceRepository>();
        builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();

        // Register command services
        builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
        builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
        builder.Services.AddScoped<IInventoryCommandService, InventoryCommandService>();
        builder.Services.AddScoped<IStorageBoxCommandService, StorageBoxCommandService>();
        builder.Services.AddScoped<IProductInstanceCommandService, ProductInstanceCommandService>();

        // Register query services
        builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
        builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
        builder.Services.AddScoped<IInventoryQueryService, InventoryQueryService>();
        builder.Services.AddScoped<IStorageBoxQueryService, StorageBoxQueryService>();
        builder.Services.AddScoped<IProductInstanceQueryService, ProductInstanceQueryService>();
        builder.Services.AddScoped<IProductFilterQueryService, ProductFilterQueryService>();

        // Register event handlers
        builder.Services.AddScoped<IEventHandler<ProductCreatedEvent>, ProductCreatedEventHandler>();
        builder.Services.AddScoped<IEventHandler<InventoryCreatedEvent>, InventoryCreatedEventHandler>();
        builder.Services.AddScoped<IEventHandler<ExpirationAlertEvent>, ExpirationAlertEventHandler>();
        builder.Services.AddScoped<IEventHandler<BarcodeScannedEvent>, BarcodeScannedEventHandler>();
        builder.Services.AddScoped<IEventHandler<CapacityThresholdEvent>, CapacityThresholdEventHandler>();
    }
}
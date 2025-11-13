using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Represents the product instance query service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="productInstanceRepository">
/// The <see cref="IProductInstanceRepository" /> to use.
/// </param>
/// <param name="productQueryRepository">
/// The <see cref="IProductQueryRepository" /> to use.
/// </param>
public class ProductInstanceQueryService(
    IProductInstanceRepository productInstanceRepository,
    IProductQueryRepository productQueryRepository)
    : IProductInstanceQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> Handle(GetProductInstancesByStorageBoxQuery query)
    {
        return await productInstanceRepository.FindByStorageBoxIdAsync(query.StorageBoxId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> Handle(GetProductInstancesByInventoryQuery query)
    {
        return await productInstanceRepository.FindByInventoryIdAsync(query.InventoryId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<object>> Handle(GetProductTypesByInventoryQuery query)
    {
        return (await productQueryRepository.GetProductTypesByInventoryAsync(query.InventoryId))
            .Select(p => new
            {
                ProductId = p.Id,
                ProductName = p.Name,
                Category = p.Category?.Name ?? "Unknown",
                TotalInstances = 0 // This would require additional logic to count instances
            });
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> Handle(GetExpiringProductsQuery query)
    {
        var threshold = DateTime.UtcNow.AddDays(query.DaysUntilExpiration);
        return await productInstanceRepository.FindExpiringProductsAsync(threshold);
    }

    /// <inheritdoc />
    public async Task<ProductInstance?> Handle(GetProductInstanceByIdQuery query)
    {
        return await productInstanceRepository.FindByIdAsync(query.ProductInstanceId);
    }
}
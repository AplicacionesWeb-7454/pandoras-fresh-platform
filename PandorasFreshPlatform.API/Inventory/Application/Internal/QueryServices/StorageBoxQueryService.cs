using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Represents the storage box query service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="storageBoxRepository">
/// The <see cref="IStorageBoxRepository" /> to use.
/// </param>
/// <param name="productInstanceRepository">
/// The <see cref="IProductInstanceRepository" /> to use.
/// </param>
public class StorageBoxQueryService(
    IStorageBoxRepository storageBoxRepository,
    IProductInstanceRepository productInstanceRepository)
    : IStorageBoxQueryService
{
    /// <inheritdoc />
    public async Task<StorageBox?> Handle(GetStorageBoxByIdQuery query)
    {
        return await storageBoxRepository.FindByIdAsync(query.StorageBoxId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<StorageBox>> Handle(GetStorageBoxesByInventoryQuery query)
    {
        return await storageBoxRepository.FindByInventoryIdAsync(query.InventoryId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<object>> Handle(GetStorageBoxContentQuery query)
    {
        var storageBox = await storageBoxRepository.GetStorageBoxWithContentAsync(query.StorageBoxId);
        if (storageBox is null) throw new Exception("Storage box not found");

        // Return content data - in a real implementation, this would be a dedicated DTO
        return storageBox.ProductInstances.Select(pi => new
        {
            ProductInstanceId = pi.Id,
            ProductName = pi.Product?.Name ?? "Unknown",
            ExpirationDate = pi.ExpirationDate.Date,
            Status = pi.Status.ToString()
        });
    }

    /// <inheritdoc />
    public async Task<IEnumerable<object>> Handle(GetProductTypesInStorageBoxQuery query)
    {
        var storageBox = await storageBoxRepository.GetStorageBoxWithContentAsync(query.StorageBoxId);
        if (storageBox is null) throw new Exception("Storage box not found");

        // Group by product type and return summary
        return storageBox.ProductInstances
            .GroupBy(pi => pi.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                ProductName = g.First().Product?.Name ?? "Unknown",
                Count = g.Count(),
                Categories = g.First().Product?.Category?.Name ?? "Unknown"
            });
    }

    /// <inheritdoc />
    public async Task<StorageBox?> Handle(GetStorageBoxWithDetailsQuery query)
    {
        return await storageBoxRepository.GetStorageBoxWithContentAsync(query.StorageBoxId);
    }
}
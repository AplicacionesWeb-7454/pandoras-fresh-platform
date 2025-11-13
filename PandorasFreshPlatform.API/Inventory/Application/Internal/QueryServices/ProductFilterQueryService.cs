using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Represents the product filter query service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="productQueryRepository">
/// The <see cref="IProductQueryRepository" /> to use.
/// </param>
public class ProductFilterQueryService(IProductQueryRepository productQueryRepository)
    : IProductFilterQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> Handle(GetFilteredProductInstancesQuery query)
    {
        return await productQueryRepository.GetFilteredProductInstancesAsync(
            query.CategoryId, query.Status, query.InventoryId, query.StorageBoxId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> Handle(GetFilteredProductTypesQuery query)
    {
        return await productQueryRepository.GetFilteredProductTypesAsync(query.CategoryId, query.InventoryId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<object>> Handle(SearchProductsQuery query)
    {
        // Implementation for search products would go here
        // Since the repository doesn't have a direct search method,
        // we might need to implement search logic here or extend the repository
        // For now, returning empty result as placeholder
        return await Task.FromResult(Enumerable.Empty<object>());
    }
}
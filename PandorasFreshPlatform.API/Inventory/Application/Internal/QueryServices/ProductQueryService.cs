using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Represents the product query service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="productRepository">
/// The <see cref="IProductRepository" /> to use.
/// </param>
public class ProductQueryService(IProductRepository productRepository)
    : IProductQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryQuery query)
    {
        return await productRepository.FindByCategoryIdAsync(query.CategoryId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> Handle(SearchProductsQuery query)
    {
        return await productRepository.SearchAsync(query.SearchTerm);
    }

    /// <inheritdoc />
    public async Task<Product?> Handle(GetProductByBarcodeQuery query)
    {
        return await productRepository.FindByBarcodeAsync(query.Barcode);
    }
}
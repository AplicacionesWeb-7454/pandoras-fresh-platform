using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the product query service in the Pandora's Fresh Platform.
/// </summary>
public interface IProductQueryService
{
    /// <summary>
    /// Handles the get all products query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllProductsQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all products in the platform.
    /// </returns>
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);

    /// <summary>
    /// Handles the get product by id query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductByIdQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="Product" /> entity.
    /// </returns>
    Task<Product?> Handle(GetProductByIdQuery query);

    /// <summary>
    /// Handles the get products by category query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductsByCategoryQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of products that belong to the category.
    /// </returns>
    Task<IEnumerable<Product>> Handle(GetProductsByCategoryQuery query);

    /// <summary>
    /// Handles the search products query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="SearchProductsQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of products matching the search term.
    /// </returns>
    Task<IEnumerable<Product>> Handle(SearchProductsQuery query);

    /// <summary>
    /// Handles the get product by barcode query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductByBarcodeQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="Product" /> entity.
    /// </returns>
    Task<Product?> Handle(GetProductByBarcodeQuery query);
}
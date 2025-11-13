using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;

namespace PandorasFreshPlatform.API.Inventory.Domain.Repositories;

/// <summary>
/// Represents the product repository in the Pandora's Fresh Platform.
/// </summary>
public interface IProductRepository : IBaseRepository<Product>
{
    /// <summary>
    /// Finds a product by barcode asynchronously.
    /// </summary>
    /// <param name="barcode">
    /// The barcode of the product to find.
    /// </param>
    /// <returns>
    /// The product with the specified barcode.
    /// </returns>
    Task<Product?> FindByBarcodeAsync(string barcode);

    /// <summary>
    /// Finds products by category id asynchronously.
    /// </summary>
    /// <param name="categoryId">
    /// The id of the category to find products by.
    /// </param>
    /// <returns>
    /// A collection of products that belong to the category.
    /// </returns>
    Task<IEnumerable<Product>> FindByCategoryIdAsync(CategoryId categoryId);

    /// <summary>
    /// Checks if a product exists by name asynchronously.
    /// </summary>
    /// <param name="name">
    /// The name of the product to check.
    /// </param>
    /// <returns>
    /// True if a product with the name exists, false otherwise.
    /// </returns>
    Task<bool> ExistsByNameAsync(string name);

    /// <summary>
    /// Searches products by search term asynchronously.
    /// </summary>
    /// <param name="searchTerm">
    /// The term to search for in product names and descriptions.
    /// </param>
    /// <returns>
    /// A collection of products matching the search term.
    /// </returns>
    Task<IEnumerable<Product>> SearchAsync(string searchTerm);

    /// <summary>
    /// Finds a product by id asynchronously using the value object.
    /// </summary>
    /// <param name="id">
    /// The id of the product to find.
    /// </param>
    /// <returns>
    /// The product with the specified id.
    /// </returns>
    Task<Product?> FindByIdAsync(ProductId id);
}
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;

namespace PandorasFreshPlatform.API.Inventory.Domain.Repositories;

/// <summary>
/// Represents the category repository in the Pandora's Fresh Platform.
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category>
{
    /// <summary>
    /// Finds a category by name asynchronously.
    /// </summary>
    /// <param name="name">
    /// The name of the category to find.
    /// </param>
    /// <returns>
    /// The category with the specified name.
    /// </returns>
    Task<Category?> FindByNameAsync(string name);

    /// <summary>
    /// Gets categories with their products asynchronously.
    /// </summary>
    /// <returns>
    /// A collection of categories with their associated products.
    /// </returns>
    Task<IEnumerable<Category>> GetWithProductsAsync();
}
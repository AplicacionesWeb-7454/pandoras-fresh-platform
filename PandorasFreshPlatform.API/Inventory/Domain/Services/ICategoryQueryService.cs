using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the category query service in the Pandora's Fresh Platform.
/// </summary>
public interface ICategoryQueryService
{
    /// <summary>
    /// Handles the get category by id query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetCategoryByIdQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="Category" /> entity.
    /// </returns>
    Task<Category?> Handle(GetCategoryByIdQuery query);

    /// <summary>
    /// Handles the get all categories query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllCategoriesQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all categories in the platform.
    /// </returns>
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);

    /// <summary>
    /// Handles the get category with products query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetCategoryWithProductsQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="Category" /> entity with its products.
    /// </returns>
    Task<Category?> Handle(GetCategoryWithProductsQuery query);
}
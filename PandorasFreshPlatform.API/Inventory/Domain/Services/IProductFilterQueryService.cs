using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the product filter query service in the Pandora's Fresh Platform.
/// </summary>
public interface IProductFilterQueryService
{
    /// <summary>
    /// Handles the get filtered product instances query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetFilteredProductInstancesQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of filtered product instances.
    /// </returns>
    Task<IEnumerable<ProductInstance>> Handle(GetFilteredProductInstancesQuery query);

    /// <summary>
    /// Handles the get filtered product types query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetFilteredProductTypesQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of filtered product types.
    /// </returns>
    Task<IEnumerable<Product>> Handle(GetFilteredProductTypesQuery query);

    /// <summary>
    /// Handles the search products query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="SearchProductsQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of search results.
    /// </returns>
    Task<IEnumerable<object>> Handle(SearchProductsQuery query);
}
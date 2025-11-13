using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a category with its products in the Pandora's Fresh Platform.
/// </summary>
/// <param name="CategoryId">
/// The id of the category to get with products
/// </param>
public record GetCategoryWithProductsQuery(CategoryId CategoryId);
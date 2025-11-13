using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get products by category in the Pandora's Fresh Platform.
/// </summary>
/// <param name="CategoryId">
/// The id of the category to get products for
/// </param>
public record GetProductsByCategoryQuery(CategoryId CategoryId);
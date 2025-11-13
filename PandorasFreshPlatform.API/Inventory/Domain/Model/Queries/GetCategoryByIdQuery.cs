using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a category by id in the Pandora's Fresh Platform.
/// </summary>
/// <param name="CategoryId">
/// The id of the category to get
/// </param>
public record GetCategoryByIdQuery(CategoryId CategoryId);
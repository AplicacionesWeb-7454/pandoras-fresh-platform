namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to search products in the Pandora's Fresh Platform.
/// </summary>
/// <param name="SearchTerm">
/// The term to search for in product names and descriptions
/// </param>
public record SearchProductsQuery(string SearchTerm);
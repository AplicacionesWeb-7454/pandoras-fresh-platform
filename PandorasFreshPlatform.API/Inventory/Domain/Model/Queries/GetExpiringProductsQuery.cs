namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get expiring products in the Pandora's Fresh Platform.
/// </summary>
/// <param name="DaysUntilExpiration">
/// The number of days until expiration to filter by
/// </param>
public record GetExpiringProductsQuery(int DaysUntilExpiration);
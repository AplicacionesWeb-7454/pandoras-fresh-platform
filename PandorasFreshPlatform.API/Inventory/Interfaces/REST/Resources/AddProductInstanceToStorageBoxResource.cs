namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Resource to add a product instance to a storage box
/// </summary>
/// <param name="ExpirationDate">
/// The expiration date of the product instance
/// </param>
/// <param name="EntryDate">
/// The entry date of the product instance
/// </param>
/// <param name="BatchNumber">
/// The batch number of the product instance
/// </param>
/// <param name="ProductId">
/// The ID of the product for the instance
/// </param>
public record AddProductInstanceToStorageBoxResource(DateTime ExpirationDate, DateTime EntryDate, string BatchNumber, int ProductId);
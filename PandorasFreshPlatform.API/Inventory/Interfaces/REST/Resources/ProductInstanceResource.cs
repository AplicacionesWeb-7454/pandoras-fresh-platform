namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Product instance resource for REST API
/// </summary>
/// <param name="Id">
/// The unique identifier of the product instance
/// </param>
/// <param name="ExpirationDate">
/// The expiration date of the product instance
/// </param>
/// <param name="EntryDate">
/// The entry date of the product instance
/// </param>
/// <param name="BatchNumber">
/// The batch number of the product instance
/// </param>
/// <param name="Status">
/// The status of the product instance
/// </param>
/// <param name="Product">
/// The product of the product instance
/// </param>
public record ProductInstanceResource(int Id, DateTime ExpirationDate, DateTime EntryDate, string BatchNumber, string Status, ProductResource Product);
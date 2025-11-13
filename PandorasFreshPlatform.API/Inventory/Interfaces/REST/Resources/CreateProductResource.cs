namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Create product resource for REST API
/// </summary>
/// <param name="Name">
/// The name of the product
/// </param>
/// <param name="Description">
/// The description of the product
/// </param>
/// <param name="Barcode">
/// The barcode of the product
/// </param>
/// <param name="CategoryId">
/// The unique identifier of the category
/// </param>
public record CreateProductResource(string Name, string Description, string Barcode, int CategoryId);
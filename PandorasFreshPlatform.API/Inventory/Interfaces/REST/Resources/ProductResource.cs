namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Product resource for REST API
/// </summary>
/// <param name="Id">
/// The unique identifier of the product
/// </param>
/// <param name="Name">
/// The name of the product
/// </param>
/// <param name="Description">
/// The description of the product
/// </param>
/// <param name="Barcode">
/// The barcode of the product
/// </param>
/// <param name="Category">
/// The category of the product
/// </param>
public record ProductResource(int Id, string Name, string Description, string Barcode, CategoryResource Category);
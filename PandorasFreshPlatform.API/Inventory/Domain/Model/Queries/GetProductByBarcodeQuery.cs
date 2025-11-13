namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a product by barcode in the Pandora's Fresh Platform.
/// </summary>
/// <param name="Barcode">
/// The barcode of the product to get
/// </param>
public record GetProductByBarcodeQuery(string Barcode);
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to update a product.
/// </summary>
/// <param name="ProductId">
/// The ID of the product to update.
/// </param>
/// <param name="Name">
/// The updated name of the product.
/// </param>
/// <param name="Description">
/// The updated description of the product.
/// </param>
/// <param name="Barcode">
/// The updated barcode of the product.
/// </param>
/// <param name="CategoryId">
/// The updated category ID for the product.
/// </param>
public record UpdateProductCommand(
    ProductId ProductId, 
    string Name, 
    string Description, 
    string Barcode, 
    CategoryId CategoryId
);
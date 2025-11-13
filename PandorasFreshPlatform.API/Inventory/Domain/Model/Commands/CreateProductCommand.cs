using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to create a product.
/// </summary>
/// <param name="Name">
/// The name of the product to create.
/// </param>
/// <param name="Description">
/// The description of the product to create.
/// </param>
/// <param name="Barcode">
/// The barcode of the product to create.
/// </param>
/// <param name="CategoryId">
/// The ID of the category for the product.
/// </param>
public record CreateProductCommand(
    string Name, 
    string Description, 
    string Barcode, 
    CategoryId CategoryId
);
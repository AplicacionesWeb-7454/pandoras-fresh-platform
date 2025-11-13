using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to update a product instance.
/// </summary>
/// <param name="ProductInstanceId">
/// The ID of the product instance to update.
/// </param>
/// <param name="ExpirationDate">
/// The updated expiration date of the product instance.
/// </param>
/// <param name="BatchNumber">
/// The updated batch number of the product instance.
/// </param>
public record UpdateProductInstanceCommand(
    ProductInstanceId ProductInstanceId, 
    DateTime ExpirationDate, 
    string BatchNumber
);
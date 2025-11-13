using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to add a product instance to a storage box.
/// </summary>
/// <param name="ExpirationDate">
/// The expiration date of the product instance.
/// </param>
/// <param name="EntryDate">
/// The entry date of the product instance.
/// </param>
/// <param name="BatchNumber">
/// The batch number of the product instance.
/// </param>
/// <param name="ProductId">
/// The ID of the product for the instance.
/// </param>
/// <param name="StorageBoxId">
/// The ID of the storage box to add the product instance to.
/// </param>
public record AddProductInstanceToStorageBoxCommand(
    DateTime ExpirationDate, 
    DateTime EntryDate, 
    string BatchNumber, 
    ProductId ProductId, 
    StorageBoxId StorageBoxId
);
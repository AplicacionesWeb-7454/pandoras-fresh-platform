using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to transfer a product instance between storage boxes.
/// </summary>
/// <param name="ProductInstanceId">
/// The ID of the product instance to transfer.
/// </param>
/// <param name="FromStorageBoxId">
/// The ID of the source storage box.
/// </param>
/// <param name="ToStorageBoxId">
/// The ID of the destination storage box.
/// </param>
public record TransferProductInstanceCommand(
    ProductInstanceId ProductInstanceId, 
    StorageBoxId FromStorageBoxId, 
    StorageBoxId ToStorageBoxId
);
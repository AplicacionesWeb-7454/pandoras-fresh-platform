using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to delete a storage box.
/// </summary>
/// <param name="StorageBoxId">
/// The ID of the storage box to delete.
/// </param>
public record DeleteStorageBoxCommand(StorageBoxId StorageBoxId);
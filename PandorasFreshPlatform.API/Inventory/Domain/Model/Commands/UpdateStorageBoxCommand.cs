using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to update a storage box.
/// </summary>
/// <param name="StorageBoxId">
/// The ID of the storage box to update.
/// </param>
/// <param name="Label">
/// The updated label of the storage box.
/// </param>
/// <param name="MaxCapacity">
/// The updated maximum capacity of the storage box.
/// </param>
/// <param name="CurrentCapacity">
/// The updated current capacity of the storage box.
/// </param>
/// <param name="TemperatureRange">
/// The updated temperature range for the storage box.
/// </param>
public record UpdateStorageBoxCommand(
    StorageBoxId StorageBoxId, 
    string Label, 
    int MaxCapacity, 
    int CurrentCapacity, 
    string TemperatureRange
);
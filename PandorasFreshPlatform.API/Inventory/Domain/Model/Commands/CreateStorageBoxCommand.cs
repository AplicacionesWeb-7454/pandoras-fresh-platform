using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to create a storage box.
/// </summary>
/// <param name="Label">
/// The label of the storage box to create.
/// </param>
/// <param name="MaxCapacity">
/// The maximum capacity of the storage box.
/// </param>
/// <param name="CurrentCapacity">
/// The current capacity of the storage box.
/// </param>
/// <param name="TemperatureRange">
/// The temperature range for the storage box.
/// </param>
/// <param name="InventoryId">
/// The ID of the inventory to add the storage box to.
/// </param>
public record CreateStorageBoxCommand(
    string Label,
    int MaxCapacity,
    int CurrentCapacity,
    string TemperatureRange,
    InventoryItemId InventoryId
);
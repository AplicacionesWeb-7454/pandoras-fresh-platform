using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;


namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class StorageBoxCreatedEvent(string label, InventoryItemId inventoryId) : IEvent
{
    public string Label { get; } = label;
    public InventoryItemId InventoryId { get; } = inventoryId;
}
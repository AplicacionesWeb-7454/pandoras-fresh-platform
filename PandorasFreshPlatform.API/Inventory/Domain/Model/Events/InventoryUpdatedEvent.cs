using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class InventoryUpdatedEvent(InventoryItemId inventoryId, string name, string location) : IEvent
{
    public InventoryItemId InventoryId { get; } = inventoryId;
    public string Name { get; } = name;
    public string Location { get; } = location;
}
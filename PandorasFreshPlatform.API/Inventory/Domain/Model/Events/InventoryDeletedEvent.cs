using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class InventoryDeletedEvent(InventoryItemId inventoryId) : IEvent
{
    public InventoryItemId InventoryId { get; } = inventoryId;
}
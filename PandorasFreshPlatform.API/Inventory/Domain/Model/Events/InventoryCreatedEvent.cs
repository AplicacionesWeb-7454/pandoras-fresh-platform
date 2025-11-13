using PandorasFreshPlatform.API.Shared.Domain.Model.Events;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class InventoryCreatedEvent(string name, string location) : IEvent
{
    public string Name { get; } = name;
    public string Location { get; } = location;
}
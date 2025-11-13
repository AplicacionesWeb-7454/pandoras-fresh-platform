using PandorasFreshPlatform.API.Shared.Domain.Model.Events;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class CategoryCreatedEvent(string name) : IEvent
{
    public string Name { get; } = name;
}
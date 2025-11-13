using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.EventHandlers;

public class InventoryCreatedEventHandler : IEventHandler<InventoryCreatedEvent>
{
    public Task Handle(InventoryCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }
    
    private static Task On(InventoryCreatedEvent domainEvent)
    {
        Console.WriteLine($"Created Inventory: {domainEvent.Name} at Location: {domainEvent.Location}");
        return Task.CompletedTask;
    }
}
using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.EventHandlers;

public class CapacityThresholdEventHandler : IEventHandler<CapacityThresholdEvent>
{
    public Task Handle(CapacityThresholdEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }
    
    private static Task On(CapacityThresholdEvent domainEvent)
    {
        var utilization = (double)domainEvent.CurrentCapacity / domainEvent.MaxCapacity * 100;
        Console.WriteLine($"Capacity Alert: Storage Box '{domainEvent.Label}' (ID: {domainEvent.StorageBoxId}) " +
                          $"is at {utilization:F1}% capacity ({domainEvent.CurrentCapacity}/{domainEvent.MaxCapacity})");
        return Task.CompletedTask;
    }
}
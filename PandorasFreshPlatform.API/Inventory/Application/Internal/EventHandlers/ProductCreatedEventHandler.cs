using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.EventHandlers;

public class ProductCreatedEventHandler : IEventHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }
    
    private static Task On(ProductCreatedEvent domainEvent)
    {
        Console.WriteLine($"Created Product: {domainEvent.Name} with Barcode: {domainEvent.Barcode} in Category: {domainEvent.CategoryId}");
        return Task.CompletedTask;
    }
}
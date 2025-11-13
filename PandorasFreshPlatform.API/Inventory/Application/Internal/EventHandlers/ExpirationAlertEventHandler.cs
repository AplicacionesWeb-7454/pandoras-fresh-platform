using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.EventHandlers;

public class ExpirationAlertEventHandler : IEventHandler<ExpirationAlertEvent>
{
    public Task Handle(ExpirationAlertEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }
    
    private static Task On(ExpirationAlertEvent domainEvent)
    {
        Console.WriteLine($"Expiration Alert: Product '{domainEvent.ProductName}' (ID: {domainEvent.ProductInstanceId}) " +
                          $"expires on {domainEvent.ExpirationDate:yyyy-MM-dd} " +
                          $"(in {domainEvent.DaysUntilExpiration} days)");
        return Task.CompletedTask;
    }
}
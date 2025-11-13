using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.EventHandlers;

public class BarcodeScannedEventHandler : IEventHandler<BarcodeScannedEvent>
{
    public Task Handle(BarcodeScannedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }
    
    private static Task On(BarcodeScannedEvent domainEvent)
    {
        Console.WriteLine($"Barcode Scanned: {domainEvent.Barcode} from Device: {domainEvent.DeviceId} at {domainEvent.ScanTime:yyyy-MM-dd HH:mm:ss}");
        return Task.CompletedTask;
    }
}
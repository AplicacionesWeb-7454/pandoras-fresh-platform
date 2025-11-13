using PandorasFreshPlatform.API.Shared.Domain.Model.Events;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class BarcodeScannedEvent(string barcode, string deviceId, DateTime scanTime) : IEvent
{
    public string Barcode { get; } = barcode;
    public string DeviceId { get; } = deviceId;
    public DateTime ScanTime { get; } = scanTime;
}
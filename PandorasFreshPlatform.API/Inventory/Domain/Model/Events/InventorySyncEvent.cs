using PandorasFreshPlatform.API.Shared.Domain.Model.Events;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class InventorySyncEvent(string deviceId, DateTime syncTime, int itemsSynced) : IEvent
{
    public string DeviceId { get; } = deviceId;
    public DateTime SyncTime { get; } = syncTime;
    public int ItemsSynced { get; } = itemsSynced;
}
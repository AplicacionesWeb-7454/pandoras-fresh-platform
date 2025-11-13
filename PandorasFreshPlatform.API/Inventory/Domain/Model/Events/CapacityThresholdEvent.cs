using PandorasFreshPlatform.API.Shared.Domain.Model.Events;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class CapacityThresholdEvent(int storageBoxId, string label, int currentCapacity, int maxCapacity) : IEvent
{
    public int StorageBoxId { get; } = storageBoxId;
    public string Label { get; } = label;
    public int CurrentCapacity { get; } = currentCapacity;
    public int MaxCapacity { get; } = maxCapacity;
}
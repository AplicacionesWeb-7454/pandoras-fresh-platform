using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class StorageBoxUpdatedEvent(StorageBoxId storageBoxId, string label) : IEvent
{
    public StorageBoxId StorageBoxId { get; } = storageBoxId;
    public string Label { get; } = label;
}
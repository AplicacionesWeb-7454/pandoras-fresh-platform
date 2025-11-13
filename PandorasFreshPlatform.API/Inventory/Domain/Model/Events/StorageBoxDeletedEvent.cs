using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class StorageBoxDeletedEvent(StorageBoxId storageBoxId) : IEvent
{
    public StorageBoxId StorageBoxId { get; } = storageBoxId;
}
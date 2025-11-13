using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;


namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ProductInstanceTransferredEvent(ProductInstanceId productInstanceId, StorageBoxId fromStorageBoxId, StorageBoxId toStorageBoxId) : IEvent
{
    public ProductInstanceId ProductInstanceId { get; } = productInstanceId;
    public StorageBoxId FromStorageBoxId { get; } = fromStorageBoxId;
    public StorageBoxId ToStorageBoxId { get; } = toStorageBoxId;
}
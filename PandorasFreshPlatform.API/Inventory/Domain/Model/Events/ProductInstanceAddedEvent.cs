using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ProductInstanceAddedEvent(ProductId productId, StorageBoxId storageBoxId, DateTime expirationDate) : IEvent
{
    public ProductId ProductId { get; } = productId;
    public StorageBoxId StorageBoxId { get; } = storageBoxId;
    public DateTime ExpirationDate { get; } = expirationDate;
}
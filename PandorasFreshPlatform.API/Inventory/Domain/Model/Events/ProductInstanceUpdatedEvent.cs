using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ProductInstanceUpdatedEvent(ProductInstanceId productInstanceId, DateTime expirationDate) : IEvent
{
    public ProductInstanceId ProductInstanceId { get; } = productInstanceId;
    public DateTime ExpirationDate { get; } = expirationDate;
}
using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ProductInstanceRemovedEvent(ProductInstanceId productInstanceId) : IEvent
{
    public ProductInstanceId ProductInstanceId { get; } = productInstanceId;
}
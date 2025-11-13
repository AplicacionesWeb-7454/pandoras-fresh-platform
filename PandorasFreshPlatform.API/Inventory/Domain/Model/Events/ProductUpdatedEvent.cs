using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ProductUpdatedEvent(ProductId productId, string name, string barcode, CategoryId categoryId) : IEvent
{
    public ProductId ProductId { get; } = productId;
    public string Name { get; } = name;
    public string Barcode { get; } = barcode;
    public CategoryId CategoryId { get; } = categoryId;
}
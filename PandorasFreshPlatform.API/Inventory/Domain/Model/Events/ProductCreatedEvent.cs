using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ProductCreatedEvent(string name, string barcode, CategoryId categoryId) : IEvent
{
    public string Name { get; } = name;
    public string Barcode { get; } = barcode;
    public CategoryId CategoryId { get; } = categoryId;
}
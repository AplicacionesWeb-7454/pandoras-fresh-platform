namespace pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Entities;

public class InventoryItemEntity
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
}
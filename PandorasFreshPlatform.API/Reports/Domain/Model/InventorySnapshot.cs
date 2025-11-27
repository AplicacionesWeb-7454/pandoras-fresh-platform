namespace pandoraFr.API.Reports.Domain.Model;

public class InventorySnapshot
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
}
namespace pandoraFr.API.Reports.Domain.Model;

public class LossRecord
{
    public string Sku { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
    public DateTime OccurredAt { get; set; }
}
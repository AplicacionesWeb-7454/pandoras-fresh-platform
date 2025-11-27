namespace pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Entities;

public class LossRecordEntity
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
    public DateTime OccurredAt { get; set; }
}
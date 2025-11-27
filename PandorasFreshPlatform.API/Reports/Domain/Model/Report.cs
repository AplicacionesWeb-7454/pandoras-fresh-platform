namespace pandoraFr.API.Reports.Domain.Model;

public class Report
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public ReportType Type { get; set; } = ReportType.Inventory;
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
}
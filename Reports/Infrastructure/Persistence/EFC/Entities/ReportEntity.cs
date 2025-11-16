using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Entities;

public class ReportEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ReportType Type { get; set; }
    public DateTime GeneratedAt { get; set; }
}
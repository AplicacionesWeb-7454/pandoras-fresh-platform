using pandoraFr.API.Reports.Domain.Model;
using pandoraFr.API.Reports.Domain.Services;

namespace pandoraFr.API.Reports.Domain.Services.Implementations;

public class ReportBuilderService : IReportBuilderService
{
    public Report BuildInventoryReport(string title, IReadOnlyList<InventorySnapshot> snapshots)
        => new Report { Title = title, Type = ReportType.Inventory, GeneratedAt = DateTime.UtcNow };

    public Report BuildLossesReport(string title, IReadOnlyList<LossRecord> losses)
        => new Report { Title = title, Type = ReportType.Losses, GeneratedAt = DateTime.UtcNow };
}
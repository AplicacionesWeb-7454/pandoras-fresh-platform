using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Domain.Services;

public interface IReportBuilderService
{
    Report BuildInventoryReport(string title, IReadOnlyList<InventorySnapshot> snapshots);
    Report BuildLossesReport(string title, IReadOnlyList<LossRecord> losses);
}
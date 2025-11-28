using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;


namespace PandorasFreshPlatform.API.Reports.Domain.Services
{
    /// <summary>
    /// Domain service that builds report aggregates from domain data.
    /// </summary>
    public interface IReportBuilderService
    {
        Report BuildInventoryReport(IEnumerable<InventoryItem> items);
        Report BuildLossesReport(IEnumerable<LossRecord> losses);
    }
}
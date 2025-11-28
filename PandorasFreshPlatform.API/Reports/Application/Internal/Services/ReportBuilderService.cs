using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Reports.Domain.Services;

namespace PandorasFreshPlatform.API.Reports.Application.Internal.Services
{
    public class ReportBuilderService : IReportBuilderService
    {
        public Report BuildInventoryReport(IEnumerable<InventoryItem> items)
        {
            var totalStock = items.Sum(i => i.Quantity);
            var totalStockValue = items.Sum(i => i.Quantity * i.Cost);

            return new Report
            {
                Title = "Inventory Report",
                Data = new
                {
                    TotalStock = totalStock,
                    TotalStockValue = totalStockValue
                }
            };
        }

        public Report BuildLossesReport(IEnumerable<LossRecord> losses)
        {
            var totalLossesValue = losses.Sum(l => l.Cost);

            return new Report
            {
                Title = "Losses Report",
                Data = new
                {
                    TotalLossesValue = totalLossesValue
                }
            };
        }
    }
}
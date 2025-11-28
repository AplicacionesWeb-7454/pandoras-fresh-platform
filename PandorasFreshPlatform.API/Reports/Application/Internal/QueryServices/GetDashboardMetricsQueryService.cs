
using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Reports.Domain.Model.Queries;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;


namespace PandorasFreshPlatform.API.Reports.Application.Internal.QueryServices
{
    /// <summary>
    /// Application query service to compute dashboard metrics from aggregates.
    /// </summary>
    public class GetDashboardMetricsQueryService
    {
        private readonly IBaseRepository<InventoryItem> _inventoryRepository;
        private readonly IBaseRepository<LossRecord> _lossesRepository;

        public GetDashboardMetricsQueryService(
            IBaseRepository<InventoryItem> inventoryRepository,
            IBaseRepository<LossRecord> lossesRepository)
        {
            _inventoryRepository = inventoryRepository;
            _lossesRepository = lossesRepository;
        }

        /// <summary>
        /// Computes aggregated metrics for the given date range.
        /// </summary>
        public async Task<object> HandleAsync(GetDashboardMetricsQuery query)
        {
            var items = (await _inventoryRepository.ListAsync()).ToList();
            var losses = (await _lossesRepository.ListAsync()).ToList();

            var totalStock = items.Sum(i => i.Quantity);
            var totalStockValue = items.Sum(i => i.Quantity * i.Cost);
            var totalLossesValue = losses.Sum(l => l.Cost);

            return new
            {
                Range = new { query.From, query.To },
                Inventory = new { totalStock, totalStockValue },
                Losses = new { totalLossesValue }
            };
        }

    }
}
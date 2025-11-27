using pandoraFr.API.Reports.Application.Internal.QueryServices;
using pandoraFr.API.Reports.Domain.Repositories;

namespace pandoraFr.API.Reports.Application.Internal.QueryServices.Handlers;

public class GetDashboardMetricsQueryHandler
{
    private readonly IInventoryReadRepository _inventoryRepo;
    private readonly ILossesReadRepository _lossesRepo;

    public GetDashboardMetricsQueryHandler(
        IInventoryReadRepository inventoryRepo,
        ILossesReadRepository lossesRepo)
    {
        _inventoryRepo = inventoryRepo;
        _lossesRepo = lossesRepo;
    }

    public async Task<(int TotalInventory, int TotalLossesUnits, decimal TotalLossesCost, int AlertsCount)>
        HandleAsync(GetDashboardMetricsQuery query)
    {
        var at = query.At ?? DateTime.UtcNow.Date;
        var from = at;
        var to = at.AddDays(1).AddTicks(-1);

        var inventory = await _inventoryRepo.GetSnapshotAsync(from, to);
        var losses = await _lossesRepo.GetLossesAsync(from.AddMonths(-1), to, null);

        var totalInventory = inventory.Sum(x => x.Quantity);
        var totalLossesUnits = losses.Sum(x => x.Quantity);
        var totalLossesCost = losses.Sum(x => x.Cost);
        var alertsCount = inventory.Count(x => x.Quantity <= 0);

        return (totalInventory, totalLossesUnits, totalLossesCost, alertsCount);
    }
}
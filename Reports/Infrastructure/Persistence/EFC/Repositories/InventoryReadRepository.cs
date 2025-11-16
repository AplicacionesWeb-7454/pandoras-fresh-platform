using pandoraFr.API.Reports.Domain.Model;
using pandoraFr.API.Reports.Domain.Repositories;

namespace pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Repositories;

public class InventoryReadRepository : IInventoryReadRepository
{
    public Task<IReadOnlyList<InventorySnapshot>> GetSnapshotAsync(DateTime from, DateTime to)
    {
        // TODO: Implement with EF Core (projection to InventorySnapshot)
        return Task.FromResult<IReadOnlyList<InventorySnapshot>>(new List<InventorySnapshot>());
    }
}
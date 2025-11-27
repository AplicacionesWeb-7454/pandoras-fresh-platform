using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Domain.Repositories;

public interface IInventoryReadRepository
{
    Task<IReadOnlyList<InventorySnapshot>> GetSnapshotAsync(DateTime from, DateTime to);
}
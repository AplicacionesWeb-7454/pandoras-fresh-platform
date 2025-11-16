using pandoraFr.API.Reports.Domain.Model;
using pandoraFr.API.Reports.Domain.Repositories;

namespace pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Repositories;

public class LossesReadRepository : ILossesReadRepository
{
    public Task<IReadOnlyList<LossRecord>> GetLossesAsync(DateTime from, DateTime to, string? productType)
    {
        // TODO: Implement with EF Core (filters + projection to LossRecord)
        return Task.FromResult<IReadOnlyList<LossRecord>>(new List<LossRecord>());
    }
}
using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Domain.Repositories;

public interface ILossesReadRepository
{
    Task<IReadOnlyList<LossRecord>> GetLossesAsync(DateTime from, DateTime to, string? productType);
}
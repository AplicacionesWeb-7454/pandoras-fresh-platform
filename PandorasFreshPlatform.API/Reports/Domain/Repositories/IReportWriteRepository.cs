using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Domain.Repositories;

public interface IReportWriteRepository
{
    Task SaveAsync(Report report);
    Task<Report?> GetAsync(Guid id);
}
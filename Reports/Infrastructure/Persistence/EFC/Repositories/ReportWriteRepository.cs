using pandoraFr.API.Reports.Domain.Model;
using pandoraFr.API.Reports.Domain.Repositories;

namespace pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Repositories;

public class ReportWriteRepository : IReportWriteRepository
{
    private static readonly Dictionary<Guid, Report> InMemory = new();

    public Task SaveAsync(Report report)
    {
        InMemory[report.Id] = report;
        return Task.CompletedTask;
    }

    public Task<Report?> GetAsync(Guid id)
    {
        InMemory.TryGetValue(id, out var report);
        return Task.FromResult(report);
    }
}
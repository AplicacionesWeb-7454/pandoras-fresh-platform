using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;


namespace PandorasFreshPlatform.API.Reports.Domain.Repositories
{
    /// <summary>
    /// Repository contract for persisting report aggregates.
    /// </summary>
    public interface IReportWriteRepository : IBaseRepository<Report> { }
}
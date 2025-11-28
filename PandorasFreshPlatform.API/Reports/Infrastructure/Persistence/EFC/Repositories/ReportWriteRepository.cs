using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Reports.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;


namespace PandorasFreshPlatform.API.Reports.Infrastructure.Persistence.EFC.Repositories
{
    /// <summary>
    /// EF Core write repository for Report aggregate, leveraging Shared.BaseRepository.
    /// </summary>
    public class ReportWriteRepository : BaseRepository<Report>, IReportWriteRepository
    {
        public ReportWriteRepository(AppDbContext context) : base(context) { }
    }
}
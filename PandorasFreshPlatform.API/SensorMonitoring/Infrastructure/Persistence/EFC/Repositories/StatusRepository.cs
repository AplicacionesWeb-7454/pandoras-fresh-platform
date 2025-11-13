namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;
using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;


public class StatusRepository : IStatusRepository
{
    private readonly SensorMonitoringDbContext _context;

    public StatusRepository(SensorMonitoringDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Status>> GetAllAsync() =>
        await _context.Statuses.ToListAsync();
}

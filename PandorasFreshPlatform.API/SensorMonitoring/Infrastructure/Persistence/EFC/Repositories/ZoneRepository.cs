namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;
using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;


public class ZoneRepository : IZoneRepository
{
    private readonly SensorMonitoringDbContext _context;

    public ZoneRepository(SensorMonitoringDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Zone>> GetAllAsync() =>
        await _context.Zones.ToListAsync();
}

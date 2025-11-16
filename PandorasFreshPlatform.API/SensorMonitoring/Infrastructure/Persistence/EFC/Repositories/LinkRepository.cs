namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;
using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;


public class LinkRepository : ILinkRepository
{
    private readonly SensorMonitoringDbContext _context;

    public LinkRepository(SensorMonitoringDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Link>> GetBySensorIdAsync(string sensorId) =>
        await _context.Links
            .Where(l => l.SensorId == sensorId)
            .ToListAsync();

    public async Task AddAsync(Link link)
    {
        _context.Links.Add(link);
        await _context.SaveChangesAsync();
    }
}

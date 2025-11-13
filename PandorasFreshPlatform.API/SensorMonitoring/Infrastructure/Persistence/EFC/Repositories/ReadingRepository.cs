namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;
using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class ReadingRepository : IReadingRepository
{
    private readonly SensorMonitoringDbContext _context;

    public ReadingRepository(SensorMonitoringDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reading>> GetBySensorIdAsync(string sensorId) =>
        await _context.Readings
            .Where(r => r.SensorId == sensorId)
            .OrderByDescending(r => r.Timestamp)
            .ToListAsync();

    public async Task AddAsync(Reading reading)
    {
        _context.Readings.Add(reading);
        await _context.SaveChangesAsync();
    }
}

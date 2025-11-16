namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Repositories;

using Microsoft.EntityFrameworkCore;
using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class SensorRepository : ISensorRepository
{
    private readonly SensorMonitoringDbContext _context;

    public SensorRepository(SensorMonitoringDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sensor>> GetAllAsync() =>
        await _context.Sensors.ToListAsync();

    public async Task<Sensor?> GetByIdAsync(string id) =>
        await _context.Sensors.FindAsync(id);

    public async Task AddAsync(Sensor sensor)
    {
        _context.Sensors.Add(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sensor sensor)
    {
        _context.Sensors.Update(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var sensor = await _context.Sensors.FindAsync(id);
        if (sensor is not null)
        {
            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();
        }
    }
}

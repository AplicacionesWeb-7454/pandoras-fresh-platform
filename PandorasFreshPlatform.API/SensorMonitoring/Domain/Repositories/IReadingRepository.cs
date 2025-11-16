namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Repositories;

using SensorMonitoring.Domain.Model.Entities;

public interface IReadingRepository
{
    Task<IEnumerable<Reading>> GetBySensorIdAsync(string sensorId);
    Task AddAsync(Reading reading);
}

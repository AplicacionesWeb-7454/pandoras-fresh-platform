namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Repositories;

using SensorMonitoring.Domain.Model.Entities;

public interface ILinkRepository
{
    Task<IEnumerable<Link>> GetBySensorIdAsync(string sensorId);
    Task AddAsync(Link link);
}

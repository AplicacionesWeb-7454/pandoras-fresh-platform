namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Repositories;

using SensorMonitoring.Domain.Model.Entities;


public interface IZoneRepository
{
    Task<IEnumerable<Zone>> GetAllAsync();
}

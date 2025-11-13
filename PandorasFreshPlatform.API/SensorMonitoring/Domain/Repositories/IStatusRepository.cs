namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Repositories;

using SensorMonitoring.Domain.Model.Entities;

public interface IStatusRepository
{
    Task<IEnumerable<Status>> GetAllAsync();
}

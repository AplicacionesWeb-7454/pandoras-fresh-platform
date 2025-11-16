namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Repositories;

using SensorMonitoring.Domain.Model.Entities;

public interface ISensorRepository
{
    Task<IEnumerable<Sensor>> GetAllAsync();
    Task<Sensor?> GetByIdAsync(string id);
    Task AddAsync(Sensor sensor);
    Task UpdateAsync(Sensor sensor);
    Task DeleteAsync(string id);
}
namespace PandorasFreshPlatform.API.SensorMonitoring.Application.Internal.QueryServices;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class SensorQueryService
{
    private readonly ISensorRepository _repository;

    public SensorQueryService(ISensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Sensor>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Sensor?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);
}

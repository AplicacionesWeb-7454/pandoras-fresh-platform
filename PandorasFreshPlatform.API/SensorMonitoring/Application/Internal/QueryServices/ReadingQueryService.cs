namespace PandorasFreshPlatform.API.SensorMonitoring.Application.Internal.QueryServices;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class ReadingQueryService
{
    private readonly IReadingRepository _repository;

    public ReadingQueryService(IReadingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Reading>> GetBySensorIdAsync(string sensorId) =>
        await _repository.GetBySensorIdAsync(sensorId);
}

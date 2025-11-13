namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Services;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class SensorDomainService
{
    private readonly ISensorRepository _sensorRepository;

    public SensorDomainService(ISensorRepository sensorRepository)
    {
        _sensorRepository = sensorRepository;
    }

    public async Task<bool> ExistsAsync(string sensorId)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorId);
        return sensor is not null;
    }

    public async Task UpdateStatusAsync(string sensorId, string newStatus)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorId);
        if (sensor is null) throw new InvalidOperationException("Sensor not found");

        sensor.Status = newStatus;
        await _sensorRepository.UpdateAsync(sensor);
    }
}

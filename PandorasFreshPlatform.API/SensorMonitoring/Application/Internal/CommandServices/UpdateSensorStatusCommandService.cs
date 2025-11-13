namespace PandorasFreshPlatform.API.SensorMonitoring.Application.Internal.CommandServices;

using SensorMonitoring.Domain.Model.Commands;
using SensorMonitoring.Domain.Repositories;

public class UpdateSensorStatusCommandService
{
    private readonly ISensorRepository _repository;

    public UpdateSensorStatusCommandService(ISensorRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(UpdateSensorStatusCommand command)
    {
        var sensor = await _repository.GetByIdAsync(command.SensorId);
        if (sensor is null) throw new InvalidOperationException("Sensor not found");

        sensor.Status = command.NewStatus;
        await _repository.UpdateAsync(sensor);
    }
}

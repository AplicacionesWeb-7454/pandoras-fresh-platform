namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Commands;

public record UpdateSensorStatusCommand(
    string SensorId,
    string NewStatus
);
namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Commands;


public record LinkSensorCommand(
    string SensorId,
    string Zone,
    string Code,
    string Notes
);

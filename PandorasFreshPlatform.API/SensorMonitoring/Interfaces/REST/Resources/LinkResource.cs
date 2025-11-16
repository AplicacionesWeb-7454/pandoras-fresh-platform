namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Resources;


public record LinkResource(
    string SensorId,
    string Zone,
    string Code,
    string Notes
);

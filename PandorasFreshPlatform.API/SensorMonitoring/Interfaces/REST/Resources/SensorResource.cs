namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Resources;

public record SensorResource(
    string Id,
    string Name,
    string Zone,
    string Location,
    string Status,
    DateTime LastReading
);

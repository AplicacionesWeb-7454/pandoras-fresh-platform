namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Resources;

public record ReadingResource(
    DateTime Timestamp,
    float Temperature,
    float Humidity,
    float Wind
);

namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.ValueObjects;


public record SensorLocation(string Latitude, string Longitude)
{
    public override string ToString() => $"{Latitude},{Longitude}";
}

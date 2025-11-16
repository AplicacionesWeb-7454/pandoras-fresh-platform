namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Entities;

public class Sensor
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Zone { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Status { get; set; } = default!;
    public DateTime LastReading { get; set; }

    // Navegación opcional
    public ICollection<Reading>? Readings { get; set; }
}
namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Entities;

public class Reading
{
    public int Id { get; set; }
    public string SensorId { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float Wind { get; set; }

    // Navegación opcional
    public Sensor? Sensor { get; set; }
}

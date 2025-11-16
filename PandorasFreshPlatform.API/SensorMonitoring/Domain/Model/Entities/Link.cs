namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Entities;


public class Link
{
    public int Id { get; set; }
    public string SensorId { get; set; } = default!;
    public string Zone { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Notes { get; set; } = default!;
}

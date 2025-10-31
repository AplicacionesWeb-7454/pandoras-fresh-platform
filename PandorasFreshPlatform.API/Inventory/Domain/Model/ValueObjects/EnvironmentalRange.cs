namespace PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

public record EnvironmentalRange
{
    public decimal? MinTemperature { get; init; }
    public decimal? MaxTemperature { get; init; }
    public decimal? MinHumidity { get; init; }
    public decimal? MaxHumidity { get; init; }
    
    public EnvironmentalRange(decimal? minTemp, decimal? maxTemp, decimal? minHumidity, decimal? maxHumidity)
    {
        MinTemperature = minTemp;
        MaxTemperature = maxTemp;
        MinHumidity = minHumidity;
        MaxHumidity = maxHumidity;
    }
    
    public bool IsWithinRange(decimal temperature, decimal humidity)
    {
        var tempInRange = (!MinTemperature.HasValue || temperature >= MinTemperature.Value) &&
                          (!MaxTemperature.HasValue || temperature <= MaxTemperature.Value);
        
        var humidityInRange = (!MinHumidity.HasValue || humidity >= MinHumidity.Value) &&
                              (!MaxHumidity.HasValue || humidity <= MaxHumidity.Value);
        
        return tempInRange && humidityInRange;
    }
}
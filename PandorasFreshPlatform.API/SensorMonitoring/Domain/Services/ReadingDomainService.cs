namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Services;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;


public class ReadingDomainService
{
    private readonly IReadingRepository _readingRepository;

    public ReadingDomainService(IReadingRepository readingRepository)
    {
        _readingRepository = readingRepository;
    }

    public async Task<Reading?> GetLatestReadingAsync(string sensorId)
    {
        var readings = await _readingRepository.GetBySensorIdAsync(sensorId);
        return readings.OrderByDescending(r => r.Timestamp).FirstOrDefault();
    }
}

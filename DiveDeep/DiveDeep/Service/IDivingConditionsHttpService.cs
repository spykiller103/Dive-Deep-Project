using DiveDeep.Models;

namespace DiveDeep.Service
{
    public interface IDivingConditionsHttpService
    {
        Task<OpenMeteoLocation?> GetLocationAsync(string location);
        Task<OpenMeteoWeatherResponse?> GetWeatherAsync(double latitude, double longitude);
        Task<OpenMeteoMarineResponse?> GetMarineAsync(double latitude, double longitude);
    }
}

using DiveDeep.Models;

namespace DiveDeep.Service
{
    public interface IDivingConditionsHttpService
    {
        Task<OpenMeteoLocation?> GetLocationByNameAsync(string location);
        Task<OpenMeteoMarineResponse?> GetLocationByCordsAsync(double latitude, double longitude);
        Task<OpenMeteoWeatherResponse?> GetWeatherAsync(double latitude, double longitude);
        Task<OpenMeteoMarineResponse?> GetMarineAsync(double latitude, double longitude);
    }
}

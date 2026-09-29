using DiveDeep.Models;
using System.Text.Json;

namespace DiveDeep.Service
{
    public class DivingConditionsHttpService : IDivingConditionsHttpService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DivingConditionsHttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<OpenMeteoLocation?> GetLocationAsync(string location)
        {
            var client = _clientFactory.CreateClient("OpenMeteoGeocoding");

            string url = $"v1/search?name={location}&count=1&countryCode=DK";

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            OpenMeteoLocationResponse? result = JsonSerializer.Deserialize<OpenMeteoLocationResponse>(json);

            return result?.Result?.FirstOrDefault();
        }

        async Task<OpenMeteoMarineResponse?> IDivingConditionsHttpService.GetMarineAsync(double latitude, double longitude)
        {
            var client = _clientFactory.CreateClient("OpenMeteoMarine");

            string url = FormattableString.Invariant(
                $"v1/marine?latitude={latitude}&longitude={longitude}&current=wave_height,sea_surface_temperature&cell_selection=sea"
            );

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            OpenMeteoMarineResponse? result = JsonSerializer.Deserialize<OpenMeteoMarineResponse>(json);

            return result;
        }

        async Task<OpenMeteoWeatherResponse?> IDivingConditionsHttpService.GetWeatherAsync(double latitude, double longitude)
        {
            var client = _clientFactory.CreateClient("OpenMeteoWeather");

            string url = FormattableString.Invariant(
                $"v1/forecast?latitude={latitude}&longitude={longitude}&current=wind_speed_10m,precipitation,weather_code&wind_speed_unit=ms"
            );

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            OpenMeteoWeatherResponse? result = JsonSerializer.Deserialize<OpenMeteoWeatherResponse>(json);

            return result;
        }
    }
}

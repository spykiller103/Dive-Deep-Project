using Azure;
using DiveDeep.Models;
using DiveDeep.Service;
using System.Text.Json;
using System.Globalization;

namespace DiveDeep.Service
{
    public class DivingConditionsHttpService : IDivingConditionsHttpService
    {
        private readonly IHttpClientFactory _clientFactory;

        public DivingConditionsHttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<OpenMeteoLocation?> GetLocationByNameAsync(string location)
        {
            HttpClient client = _clientFactory.CreateClient("OpenMeteoGeocoding");

            OpenMeteoLocationResponse? response = await client.GetFromJsonAsync<OpenMeteoLocationResponse>
                ($"v1/search?name={location}&count=1&countryCode=DK");

            return response?.Results?.FirstOrDefault();
        }

        public async Task<OpenMeteoMarineResponse?> GetLocationByCordsAsync(double latitude, double longitude)
        {
            var client = _clientFactory.CreateClient("OpenMeteoMarine");

            string url = FormattableString.Invariant(
                $"v1/marine?latitude={latitude}&longitude={longitude}&current=wave_height,sea_surface_temperature&cell_selection=sea"
            );

            HttpResponseMessage response = await client.GetAsync(url);

            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Open-Meteo fejl {response.StatusCode}: {json}"
                );
            }

            OpenMeteoMarineResponse? result =
                JsonSerializer.Deserialize<OpenMeteoMarineResponse>(json);

            return result;
        }

        public async Task<OpenMeteoMarineResponse?> GetMarineAsync(double latitude, double longitude)
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

        public async Task<OpenMeteoWeatherResponse?> GetWeatherAsync(double latitude, double longitude)
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

using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class CurrentWeather
    {
            [JsonPropertyName("wind_speed_10m")]
            public double WindSpeed { get; set; }

            public double Precipitation { get; set; }

            [JsonPropertyName("weather_code")]
            public int WeatherCode { get; set; }
    }
}

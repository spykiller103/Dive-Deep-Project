using System.Text.Json.Serialization;

namespace DiveDeepShared.Models
{
    public class OpenMeteoWeatherResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set;  }
    }
}

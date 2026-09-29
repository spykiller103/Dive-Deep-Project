using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class OpenMeteoWeatherResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set;  }
    }
}

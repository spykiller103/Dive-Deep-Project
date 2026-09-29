using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class OpenMeteoWeatherResponse
    {
        public CurrentWeather? Current { get; set;  }
    }
}

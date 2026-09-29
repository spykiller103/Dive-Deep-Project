using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class CurrentMarine
    {
        [JsonPropertyName("wave_height")]
        public double? WaveHeight { get; set; }

        [JsonPropertyName("sea_surface_tempature")]
        public double? WaterTemperature { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class OpenMeteoMarineResponse
    {
        [JsonPropertyName("current")]
        public CurrentMarine? Current { get; set; }
    }

}

using System.Text.Json.Serialization;

namespace DiveDeepShared.Models
{
    public class OpenMeteoMarineResponse
    {
        [JsonPropertyName("current")]
        public CurrentMarine? Current { get; set; }
    }

}

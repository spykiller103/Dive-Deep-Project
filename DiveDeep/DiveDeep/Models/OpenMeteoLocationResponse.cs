using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class OpenMeteoLocationResponse
    {
        [JsonPropertyName("result")]
        public List <OpenMeteoLocation>? Result { get; set; }
    }
}

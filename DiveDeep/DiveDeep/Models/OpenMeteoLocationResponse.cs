using System.Text.Json.Serialization;

namespace DiveDeep.Models
{
    public class OpenMeteoLocationResponse
    {
        public List<OpenMeteoLocation>? Results { get; set; }
    }
}

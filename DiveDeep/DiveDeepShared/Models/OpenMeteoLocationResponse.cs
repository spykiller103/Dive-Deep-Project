using System.Text.Json.Serialization;

namespace DiveDeepShared.Models
{
    public class OpenMeteoLocationResponse
    {
        public List<OpenMeteoLocation>? Results { get; set; }
    }
}

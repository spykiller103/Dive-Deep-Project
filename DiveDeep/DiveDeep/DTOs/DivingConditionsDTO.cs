using DiveDeep.Models;

namespace DiveDeep.DTOs
{
    public class DivingConditionsDTO
    {
        public OpenMeteoLocation? Location { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public OpenMeteoWeatherResponse? Weather { get; set; }
        public OpenMeteoMarineResponse? Marine { get; set; }

        public bool IsThunderstorm { get; set; }
        public bool IsSuitableForDiving { get; set; }

        public List<string> Reasons { get; set; } = new List<string>();

        public string? RecommendedSuit { get; set; }
    }
}

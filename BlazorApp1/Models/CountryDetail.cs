using static BlazorApp1.Components.Pages.CountryDetails;
using System.Text.Json.Serialization;

namespace BlazorApp1
{
    public class CountryDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonPropertyName("name")]
        public NameInfo Name { get; set; }

        [JsonPropertyName("cca2")]
        public string Cca2 { get; set; }

        [JsonPropertyName("capital")]
        public List<string> Capital { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        [JsonPropertyName("area")]
        public double Area { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        [JsonPropertyName("currencies")]
        public Dictionary<string, CurrencyInfo> Currencies { get; set; }

        [JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [JsonPropertyName("timezones")]
        public List<string> Timezones { get; set; }

        [JsonPropertyName("independent")]
        public bool Independent { get; set; }

        [JsonPropertyName("flags")]
        public FlagInfo Flags { get; set; }

        [JsonPropertyName("maps")]
        public MapInfo Maps { get; set; }
    }
}

using static BlazorApp1.Components.Pages.CountryDetails;
using System.Text.Json.Serialization;

namespace BlazorApp1
{
    public class Country
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonPropertyName("name")]
        public NameInfo Name { get; set; }

        [JsonPropertyName("capital")]
        public List<string> Capital { get; set; }

        [JsonPropertyName("currencies")]
        public Dictionary<string, CurrencyInfo> Currencies { get; set; }

        [JsonPropertyName("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [JsonPropertyName("area")]
        public double Area { get; set; }
    }
}

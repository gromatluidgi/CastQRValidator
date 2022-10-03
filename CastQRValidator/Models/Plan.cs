using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CastQRValidator.Models
{
    public class Plan
    {
        [JsonPropertyName("Name")]
        public string Name { get; }

        public Collection<string> SampleNames { get; }
    }
}

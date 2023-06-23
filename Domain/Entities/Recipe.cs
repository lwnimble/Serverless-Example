using Domain.Common;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public sealed class Recipe : BaseEntity
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("ingredients")]
        public List<Ingredient> Ingredients { get; set; } = new();
    }
}

using Domain.Common;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public sealed class Ingredient : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}

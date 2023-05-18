using Newtonsoft.Json;

namespace SharedLibrary.Models
{
    public class Ingredient
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity { get; set; }
    }
}

using Newtonsoft.Json;

namespace SharedLibrary.Models
{
    public class Recipe
    {
        [JsonProperty("id")] 
        public string? Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}

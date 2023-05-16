using Newtonsoft.Json;

namespace SharedLibrary.Models
{
    public class ShoppingList
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public DateTime? Created { get; set; }
        public List<Ingredient> Items { get; set; } = new List<Ingredient>();
    }
}

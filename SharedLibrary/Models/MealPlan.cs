using Newtonsoft.Json;

namespace SharedLibrary.Models
{
    internal class MealPlan
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public DateTime? Created { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}

using Application.Features.IngredientFeatures;

namespace Application.Features.RecipeFeatures
{
    public sealed record RecipeDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
    }
}

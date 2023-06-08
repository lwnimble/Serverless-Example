namespace Application.Features.IngredientFeatures.GetIngredientsByCategory
{
    public sealed record GetIngredientsByCategoryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity { get; set; }
    }
}

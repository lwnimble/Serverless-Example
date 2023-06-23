namespace Application.Features.IngredientFeatures
{
    public sealed record IngredientDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity { get; set; }
    }
}

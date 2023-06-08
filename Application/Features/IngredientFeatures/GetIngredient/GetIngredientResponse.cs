namespace Application.Features.IngredientFeatures.GetIngredient
{
    public sealed record GetIngredientResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity { get; set; }
    }
}

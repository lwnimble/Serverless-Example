namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed record CreateIngredientResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity{ get; set; }
    }
}

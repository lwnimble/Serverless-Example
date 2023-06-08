using Domain.Entities;

namespace Application.Features.IngredientFeatures.GetAllIngredient
{
    public sealed record GetAllIngredientResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity { get; set; }
    }
}

using Domain.Common;

namespace Domain.Entities
{
    public sealed class Recipe : BaseEntity
    {
        public Uri Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
    }
}

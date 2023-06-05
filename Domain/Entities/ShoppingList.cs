using Domain.Common;

namespace Domain.Entities
{
    public sealed class ShoppingList : BaseEntity
    {
        public DateTime? Created { get; set; }
        public List<Ingredient> Items { get; set; } = new();
    }
}

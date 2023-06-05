using Domain.Common;

namespace Domain.Entities
{
    internal sealed class MealPlan : BaseEntity
    {
        public DateTime? Created { get; set; }
        public List<Recipe> Recipes { get; set; } = new();
    }
}

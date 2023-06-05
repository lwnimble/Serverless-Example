using Domain.Common;

namespace Domain.Entities
{
    public sealed class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public long Quantity { get; set; }
    }
}

using Domain.Entities;

namespace Application.Repositories
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        public Task<List<Ingredient>> GetByCategory(string category, CancellationToken cancellationToken);
    }
}

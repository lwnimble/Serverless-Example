using Application.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using SharedLibrary.Utilities;

namespace Persistence.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {

        public IngredientRepository(CosmosContext cosmosContext, ILogger<IngredientRepository> logger)
            : base(cosmosContext, "ingredients", "/category", logger)
        {
        }

        public async Task<List<Ingredient>> GetByCategory(string category, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Finding ingredients with category {category}", category);
            return await GetByFunction(ingredient => ingredient.Category.ToLower() == category.ToLower(), cancellationToken);
        }
    }
}
        
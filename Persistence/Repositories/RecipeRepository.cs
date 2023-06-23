using Application.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using SharedLibrary.Utilities;

namespace Persistence.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CosmosContext context, ILogger<RecipeRepository> logger) 
            : base(context, "recipes", "/nationality", logger)
        {
        }
    }
}

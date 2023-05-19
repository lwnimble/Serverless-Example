using Microsoft.Azure.Cosmos;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CosmosClientUtilities _cosmosUtils;
        private const string Container = "recipes";
        private const string PartitionKey = "/Category";

        public RecipeRepository(CosmosClientUtilities cosmosClientUtilities)
        {
            _cosmosUtils = cosmosClientUtilities;
        }
        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetRecipe(string id)
        {
            throw new NotImplementedException();
        }
    }
}

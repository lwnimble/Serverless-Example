using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly Container _container;
        private readonly ILogger _logger;
        private const string Container = "recipes";
        private const string PartitionKey = "/Nationality";

        public RecipeRepository(CosmosClientUtilities cosmosClientUtilities, ILogger<RecipeRepository> logger)
        {
            _logger = logger;
            _container = cosmosClientUtilities.GetContainer(Container, PartitionKey).Result;
        }
        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            return await _container.CreateItemAsync(recipe);
        }

        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            return await _container.UpsertItemAsync(recipe);
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            var iterator = _container.GetItemLinqQueryable<Recipe>()
                .ToFeedIterator();

            var recipes = new List<Recipe>();
            while (iterator.HasMoreResults)
            {
                var results = await iterator.ReadNextAsync();
                recipes.AddRange(results);
            }

            return recipes;
        }

        public async Task<Recipe?> GetRecipe(string id, string nationality)
        {
            try
            {
                return await _container.ReadItemAsync<Recipe>(id, new PartitionKey(nationality));
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, $"Failed to find recipe with Id: {id} in Nationality: {nationality}");
                return null;
            }
        }
    }
}

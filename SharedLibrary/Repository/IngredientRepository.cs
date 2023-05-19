using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models;
using SharedLibrary.Utilities;
using System.Net;

namespace SharedLibrary.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ILogger<IngredientRepository> _logger;

        private readonly Container _container;
        private const string Container = "ingredients";
        private const string PartitionKey = "/Category";

        public IngredientRepository(CosmosClientUtilities cosmosClientUtilities, ILogger<IngredientRepository> logger)
        {
            _logger = logger;
            _container = cosmosClientUtilities.GetContainer(Container, PartitionKey).Result;
        }

        public async Task<Ingredient> AddIngredient(Ingredient ingredient)
        {
            var response = await _container.CreateItemAsync(ingredient);
            return response.Resource;
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            var iterator = _container.GetItemLinqQueryable<Ingredient>()
                .ToFeedIterator();

            var ingredients = new List<Ingredient>();
            while (iterator.HasMoreResults)
            {
                var results = await iterator.ReadNextAsync();
                ingredients.AddRange(results.Resource);
            }

            return ingredients;
        }

        public async Task<List<Ingredient>> GetIngredientCategory(string category)
        {
            var iterator = _container.GetItemLinqQueryable<Ingredient>()
                .Where(i => i.Category.ToLower() == category.ToLower())
                .ToFeedIterator();

            var ingredients = new List<Ingredient>();
            while (iterator.HasMoreResults)
            {
                var results = await iterator.ReadNextAsync();
                ingredients.AddRange(results);
            }

            return ingredients;
        }

        public async Task<Ingredient?> GetIngredient(string id, string category)
        {
            try
            {
                return await _container.ReadItemAsync<Ingredient>(id, new PartitionKey(category));
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, $"Failed to find ingredient with id: {id} in category: {category}");
                return null;
            }
        }
    }
}

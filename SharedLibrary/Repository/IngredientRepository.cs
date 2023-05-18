using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SharedLibrary.Models;

namespace SharedLibrary.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _database;
        private const string Container = "ingredients";

        public IngredientRepository(CosmosClientFactory cosmosClientFactory)
        {
            _cosmosClient = cosmosClientFactory.CreateClient();
            _database = cosmosClientFactory.DatabaseName;
        }

        public async Task<Ingredient> AddIngredient(Ingredient ingredient)
        {
            Container container = GetContainer();

            var response = await container.CreateItemAsync(ingredient);
            return response.Resource;
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            var container = GetContainer();
            var iterator = container.GetItemLinqQueryable<Ingredient>()
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
            var container = GetContainer();
            var iterator = container.GetItemLinqQueryable<Ingredient>()
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

        private Container GetContainer()
        {
            var database = _cosmosClient.GetDatabase(id: _database);
            var container = database.GetContainer(Container);
            return container;
        }
    }
}

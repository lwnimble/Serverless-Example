using Microsoft.Azure.Cosmos;
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

        public Task<ItemResponse<Ingredient>> CreateProductAsync(Ingredient ingredient)
        {
            var database = _cosmosClient.GetDatabase(id: _database);
            var container = database.GetContainer(Container);

            return container.CreateItemAsync(ingredient);
        }
    }
}

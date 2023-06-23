using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace SharedLibrary.Utilities
{
    public class CosmosContext
    {
        private readonly CosmosClient _client;
        private readonly string _databaseName;

        public CosmosContext(CosmosClient client, IConfiguration config)
        {
            _databaseName = config["DatabaseName"];
            _client = client;
        }

        public async Task<Container> GetContainer(string containerName, string partitionKey)
        {
            var database = await _client.CreateDatabaseIfNotExistsAsync(id: _databaseName);
            return await database.Database.CreateContainerIfNotExistsAsync(new ContainerProperties(containerName, partitionKey));
        }
    }
}

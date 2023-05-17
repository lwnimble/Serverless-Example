using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using RecipeApiFunction.DependencyInjection;

namespace SharedLibrary.Repository
{
    public class CosmosClientFactory
    {
        private readonly string _databaseUrl;
        private readonly string _databasePrimaryKey;
        public string DatabaseName { get; }

        public CosmosClientFactory(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseUrl = databaseConfig.Value.DatabaseURI;
            _databasePrimaryKey = databaseConfig.Value.DatabasePrimaryKey;
            DatabaseName = databaseConfig.Value.DatabaseName;
        }

        public CosmosClient CreateClient()
        {
            return new CosmosClient(_databaseUrl, _databasePrimaryKey);
        }

    }
}

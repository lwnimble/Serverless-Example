using Microsoft.Azure.Cosmos;

namespace SharedLibrary.Repository
{
    public class CosmosClientFactory
    {
        private readonly string _databaseUrl;
        private readonly string _databasePrimaryKey;
        public string DatabaseName { get; private set; }

        public CosmosClientFactory(string databaseUrl, string databasePrimaryKey, string databaseName)
        {
            _databaseUrl = databaseUrl;
            _databasePrimaryKey = databasePrimaryKey;
            DatabaseName = databaseName;
        }

        public CosmosClient CreateClient()
        {
            return new CosmosClient(_databaseUrl, _databasePrimaryKey);
        }

    }
}

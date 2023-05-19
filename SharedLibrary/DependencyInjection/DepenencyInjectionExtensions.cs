using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharedLibrary.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCosmosClient(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton<CosmosClient>(service => new CosmosClient(configuration["PrimaryConnectionString"]));
        }
    }
}

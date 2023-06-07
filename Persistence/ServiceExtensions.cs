using Application.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using SharedLibrary.Utilities;
using System.Net.Http.Headers;

namespace Persistence
{
    public  static class ServiceExtensions
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSingleton(service => new CosmosClient(configuration["PrimaryConnectionString"]))
                .AddTransient<CosmosContext>()
                .AddScoped<IIngredientRepository, IngredientRepository>();
        }
    }
}

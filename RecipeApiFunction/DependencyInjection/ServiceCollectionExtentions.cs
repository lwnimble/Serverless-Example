using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Repository;
using SharedLibrary.Utilities;
using System.Drawing;

namespace RecipeApiFunction.DependencyInjection
{
    internal static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddFunctionServices(this IServiceCollection services)
        {
            return services.AddTransient<CosmosClientUtilities>()
                .AddTransient<IIngredientRepository, IngredientRepository>();
        }

    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Repository;

namespace RecipeApiFunction.DependencyInjection
{
    internal static class Extensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DatabaseConfig>(config.GetSection(nameof(DatabaseConfig)));
            return services;
        }

        public static IServiceCollection AddFunctionServices(this IServiceCollection services)
        {
            return services.AddTransient<CosmosClientFactory>()
                .AddTransient<IIngredientRepository, IngredientRepository>();
        }
    }
}

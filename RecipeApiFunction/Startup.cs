using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeApiFunction.DependencyInjection;
using SharedLibrary.DependencyInjection;

[assembly: FunctionsStartup(typeof(RecipeApiFunction.Startup))]

namespace RecipeApiFunction
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);

            builder.Services.AddSingleton(configuration)
                .AddCosmosClient(configuration)
                .AddFunctionServices();
        }

        private static IConfiguration BuildConfiguration(string applicationRootPath)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(applicationRootPath)
                .AddJsonFile("local.settings.json", optional:true, reloadOnChange: true)
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return config;
        }
    }
}

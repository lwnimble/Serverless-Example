using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using System;

namespace ProductsApi
{
    public class ProductsFunction
    {
        private readonly ILogger<ProductsFunction> _logger;
        private readonly IIngredientRepository _ingredientRepository;

        public ProductsFunction(ILogger<ProductsFunction> log, IIngredientRepository ingredientRepository)
        {
            _logger = log;
            _ingredientRepository = ingredientRepository;
        }

        [FunctionName("ProductsFunction")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            var ingredient = new Ingredient
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Meat",
                Name = "Steak",
                Quantity = 4
            };

            var response = await _ingredientRepository.CreateProductAsync(ingredient);

            return new OkObjectResult(response.Resource); 
        }
    }
}


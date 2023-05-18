using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using SharedLibrary.Utilities;
using System;
using System.Collections.Generic;

namespace RecipeApiFunction
{
    public class RecipeApiFunction
    {
        private readonly ILogger<RecipeApiFunction> _logger;
        private readonly IIngredientRepository _ingredientRepository;

        public RecipeApiFunction(ILogger<RecipeApiFunction> log, IIngredientRepository ingredientRepository)
        {
            _logger = log;
            _ingredientRepository = ingredientRepository;
        }

        [FunctionName("AddIngredient")]
        [OpenApiOperation(operationId: "PostIngredient", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Ingredient), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "text/plain", bodyType: typeof(string), Description = "The BadRequest response")]
        public async Task<IActionResult> PostIngredient(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "ingredient")] HttpRequest req)
        {
            if (req.Headers.ContentLength == 0)
            {
                return new BadRequestObjectResult("Body containing an ingredient is required");
            }
            
            var success = StreamUtilities.TryParseStream<Ingredient>(req.Body, out var ingredient);
            if (!success)
            {
                return new BadRequestObjectResult("Body containing an ingredient is required");
            }

            ingredient.Id ??= Guid.NewGuid().ToString();

            var response = await _ingredientRepository.AddIngredient(ingredient);

            return new OkObjectResult(response); 
        }

        [FunctionName("GetAllIngredients")]
        [OpenApiOperation(operationId: "GetIngredients", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
            In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
            bodyType: typeof(List<Ingredient>), Description = "The OK response")]
        public async Task<IActionResult> GetIngredients(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ingredient")]
            HttpRequest req)
        {
            var response = await _ingredientRepository.GetAllIngredients();
            return new OkObjectResult(response);
        }

        [FunctionName("GetCategory")]
        [OpenApiOperation(operationId: "GetIngredients", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
            In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
            bodyType: typeof(List<Ingredient>), Description = "The OK response")]
        public async Task<IActionResult> GetIngredientsForCategory(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ingredient/{category:alpha}")] HttpRequest req,
        string category)
        {
            var response = await _ingredientRepository.GetIngredientCategory(category);
            return new OkObjectResult(response);
        }
    }
}

using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SharedLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RecipeApiFunction
{
    public class RecipeFunctions
    {
        private readonly ILogger<RecipeFunctions> _logger;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeFunctions(ILogger<RecipeFunctions> logger, IRecipeRepository recipeRepository)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
        }

        //[FunctionName("AddRecipe")]
        //[OpenApiOperation(operationId: "AddRecipe", tags: new[] { "Recipes" })]
        //[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
        //    In = OpenApiSecurityLocationType.Query)]
        //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
        //    bodyType: typeof(Recipe), Description = "The OK response")]
        //[OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "text/plain",
        //    bodyType: typeof(string), Description = "The BadRequest response")]
        //public async Task<IActionResult> PostRecipe(
        //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "recipe")]
        //    HttpRequest req)
        //{
        //    var validRequest = RequestValidationUtilities.ValidateRequest<Recipe>(req, out var recipe);

        //    if (!validRequest)
        //    {
        //        return new BadRequestObjectResult("Invalid request. Body must contain a recipe");
        //    }

        //    recipe.Id ??= Guid.NewGuid().ToString();

        //    var response = await _recipeRepository.AddRecipe(recipe);

        //    return new OkObjectResult(response);
        //}

        //[FunctionName("GetAllRecipes")]
        //[OpenApiOperation(operationId: "GetAllRecipes", tags: new[] { "Recipes" })]
        //[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
        //    In = OpenApiSecurityLocationType.Query)]
        //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
        //    bodyType: typeof(List<Ingredient>), Description = "The OK response")]
        //public async Task<IActionResult> GetIngredients(
        //    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "recipe")]
        //    HttpRequest req)
        //{
        //    var response = await _recipeRepository.GetAllRecipes();
        //    return new OkObjectResult(response);
        //}

        //[FunctionName("GetRecipe")]
        //[OpenApiOperation(operationId: "GetRecipe", tags: new[] { "Recipes" })]
        //[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
        //    In = OpenApiSecurityLocationType.Query)]
        //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Ingredient), Description = "The OK response")]
        //[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Description = "The not found response")]
        //[OpenApiParameter("nationality", In = ParameterLocation.Path, Type = typeof(string), Description = "The **nationality** parameter", Required = true)]
        //[OpenApiParameter("id", In = ParameterLocation.Path, Type = typeof(string), Description = "The **id** parameter", Required = true)]
        //public async Task<IActionResult> GetIngredient(
        //    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "recipe/{nationality:alpha}/{id}")]
        //    HttpRequest req, string id, string nationality)
        //{
        //    var response = await _recipeRepository.GetRecipe(id, nationality);

        //    if (response == null)
        //    {
        //        return new NotFoundResult();
        //    }

        //    return new OkObjectResult(response);
        //}
    }
}


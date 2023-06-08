using Application.Common.Behaviours;
using Application.Common.Exceptions;
using Application.Features.IngredientFeatures.CreateIngredient;
using Application.Features.IngredientFeatures.GetAllIngredient;
using Application.Features.IngredientFeatures.GetIngredient;
using Application.Features.IngredientFeatures.GetIngredientsByCategory;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RecipeApiFunction
{
    public class IngredientsFunctions
    {
        private readonly ILogger<IngredientsFunctions> _logger;
        private readonly IMediator _mediator;

        public IngredientsFunctions(IMediator mediator, ILogger<IngredientsFunctions> log)
        {
            _logger = log;
            _mediator = mediator;
        }

        [FunctionName("AddIngredient")]
        [OpenApiOperation(operationId: "AddIngredient", tags: new[] { "Ingredients" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Ingredient), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "text/plain", bodyType: typeof(string), Description = "The BadRequest response")]
        public async Task<IActionResult> PostIngredient(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "ingredient")] 
            CreateIngredientRequest req, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(req, cancellationToken);
                return new OkObjectResult(response);
            }
            catch (ValidationException ex)
            {
                return ex.ToBadRequestResponse();
            }
        }

        [FunctionName("GetAllIngredients")]
        [OpenApiOperation(operationId: "GetAllIngredients", tags: new[] { "Ingredients" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
            In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
            bodyType: typeof(List<Ingredient>), Description = "The OK response")]
        public async Task<IActionResult> GetIngredients(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ingredient")]
            GetAllIngredientRequest req, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(req, cancellationToken);

            return new OkObjectResult(response);
        }

        [FunctionName("GetIngredientsByCategory")]
        [OpenApiOperation(operationId: "GetByCategory", tags: new[] { "Ingredients" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
            In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
            bodyType: typeof(List<Ingredient>), Description = "The OK response")]
        [OpenApiParameter("category", In = ParameterLocation.Path, Type = typeof(string), Description = "The **category** parameter", Required = true)]
        public async Task<IActionResult> GetIngredientsForCategory(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ingredient/{category:alpha}")]
            HttpRequest req, string category, CancellationToken cancellationToken)
        {
            var request = new GetIngredientsByCategoryRequest(category);
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return new OkObjectResult(response);
            }
            catch (ValidationException ex)
            {
                return ex.ToBadRequestResponse();
            }
        }

        [FunctionName("GetIngredientById")]
        [OpenApiOperation(operationId: "GetIngredientById", tags: new[] { "Ingredients" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code",
            In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Ingredient), Description = "The OK response")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Description = "The not found response")]
        [OpenApiParameter("category", In = ParameterLocation.Path, Type = typeof(string), Description = "The **category** parameter", Required = true)]
        [OpenApiParameter("id", In = ParameterLocation.Path, Type = typeof(string), Description = "The **id** parameter", Required = true)]
        public async Task<IActionResult> GetIngredient(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ingredient/{category:alpha}/{id}")]
            HttpRequest req, string id, string category, CancellationToken cancellationToken)
        {
            var request = new GetIngredientRequest(id, category);

            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return new OkObjectResult(response);
            }
            catch (ValidationException ex)
            {
                return ex.ToBadRequestResponse();
            }
        }
    }
}

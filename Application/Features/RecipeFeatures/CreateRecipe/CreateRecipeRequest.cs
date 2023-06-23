using Application.Features.IngredientFeatures;
using MediatR;

namespace Application.Features.RecipeFeatures.CreateRecipe
{
    public sealed record CreateRecipeRequest(string Url, string Name, string Description, string Nationality,
        List<IngredientDto> Ingredients) : IRequest<RecipeDto>;
}

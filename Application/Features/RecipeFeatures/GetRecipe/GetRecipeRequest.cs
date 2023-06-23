using MediatR;

namespace Application.Features.RecipeFeatures.GetRecipe
{
    public sealed record GetRecipeRequest(string Id, string Nationality) : IRequest<RecipeDto>;
}

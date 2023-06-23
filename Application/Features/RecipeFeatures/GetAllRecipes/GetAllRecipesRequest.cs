using MediatR;

namespace Application.Features.RecipeFeatures.GetAllRecipes
{
    public sealed record GetAllRecipesRequest : IRequest<List<RecipeDto>>;
}

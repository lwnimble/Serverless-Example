using MediatR;

namespace Application.Features.IngredientFeatures.GetIngredientsByCategory
{
    public sealed record GetIngredientsByCategoryRequest(string CategoryName) 
        : IRequest<List<GetIngredientsByCategoryResponse>>;
}

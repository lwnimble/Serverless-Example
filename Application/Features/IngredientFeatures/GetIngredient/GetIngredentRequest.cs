using MediatR;

namespace Application.Features.IngredientFeatures.GetIngredient
{
    public sealed record GetIngredientRequest(string Id, string Category) : IRequest<IngredientDto>;
}

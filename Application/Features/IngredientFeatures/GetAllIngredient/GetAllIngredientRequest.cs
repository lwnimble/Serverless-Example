using MediatR;

namespace Application.Features.IngredientFeatures.GetAllIngredient
{
    public sealed record GetAllIngredientRequest : IRequest<List<GetAllIngredientResponse>>;
}

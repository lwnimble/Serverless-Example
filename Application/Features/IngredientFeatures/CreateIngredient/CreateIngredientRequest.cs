using MediatR;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed record CreateIngredientRequest() : IRequest<CreateIngredientResponse>
    {
    }
}

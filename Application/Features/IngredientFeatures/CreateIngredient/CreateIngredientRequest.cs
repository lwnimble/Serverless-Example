using Domain.Entities;
using MediatR;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed record CreateIngredientRequest(string Name, string Category, long Quantity) : IRequest<CreateIngredientResponse>
    {
    }
}

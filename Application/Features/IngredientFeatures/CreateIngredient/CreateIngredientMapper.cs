using AutoMapper;
using Domain.Entities;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed class CreateIngredientMapper : Profile
    {
        public CreateIngredientMapper()
        {
            CreateMap<CreateIngredientRequest, Ingredient>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}

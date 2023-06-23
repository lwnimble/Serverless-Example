using AutoMapper;
using Domain.Entities;

namespace Application.Features.IngredientFeatures.GetIngredient
{
    public sealed class GetIngredientMapper : Profile
    {
        public GetIngredientMapper()
        {
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}

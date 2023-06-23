using AutoMapper;
using Domain.Entities;

namespace Application.Features.IngredientFeatures.GetAllIngredient
{
    public sealed class GetAllIngredientMapper : Profile
    {
        public GetAllIngredientMapper()
        {
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}

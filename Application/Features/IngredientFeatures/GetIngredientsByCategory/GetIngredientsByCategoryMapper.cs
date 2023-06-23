using AutoMapper;
using Domain.Entities;

namespace Application.Features.IngredientFeatures.GetIngredientsByCategory
{
    public sealed class GetIngredientsByCategoryMapper : Profile
    {
        public GetIngredientsByCategoryMapper()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}

using AutoMapper;
using Domain.Entities;

namespace Application.Features.RecipeFeatures.GetRecipe
{
    public sealed class GetRecipeMapper : Profile
    {
        public GetRecipeMapper()
        {
            CreateMap<Recipe, RecipeDto>();
        }
    }
}

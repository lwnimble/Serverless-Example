using AutoMapper;
using Domain.Entities;

namespace Application.Features.RecipeFeatures.GetAllRecipes
{
    public sealed class GetAllRecipesMapper : Profile
    {
        public GetAllRecipesMapper()
        {
            CreateMap<Recipe, RecipeDto>();
        }
    }
}

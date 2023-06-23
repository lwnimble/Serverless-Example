using Application.Features.IngredientFeatures;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.RecipeFeatures.CreateRecipe
{
    public sealed class CreateRecipeMapper : Profile
    {
        public CreateRecipeMapper()
        {
            CreateMap<CreateRecipeRequest, Recipe>()
                .ForMember(r => r.Ingredients,
                    opt => opt.MapFrom((createRecipeRequest, recipe, i, context)
                        => context.Mapper.Map<List<Ingredient>>(createRecipeRequest.Ingredients)));

            //CreateMap<CreateRecipeRequest, Recipe>()
            //    .ForMember(r => r.Ingredients,
            //        opt => opt.MapFrom((r) => r.Ingredients));


            CreateMap<Recipe, RecipeDto>()
                .ForMember(r => r.Ingredients,
                    opt => opt.MapFrom((recipeDto, recipe, i, context) =>
                        context.Mapper.Map<List<IngredientDto>>(recipeDto.Ingredients)));
        }
    }
}

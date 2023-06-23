using FluentValidation;

namespace Application.Features.IngredientFeatures.GetIngredientsByCategory
{
    public sealed class GetIngredientsByCategoryValidator : AbstractValidator<GetIngredientsByCategoryRequest>
    {
        public GetIngredientsByCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().MinimumLength(2);
        }
    }
}

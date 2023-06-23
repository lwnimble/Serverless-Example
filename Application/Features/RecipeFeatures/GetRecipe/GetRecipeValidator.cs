using FluentValidation;

namespace Application.Features.RecipeFeatures.GetRecipe
{
    public sealed class GetRecipeValidator : AbstractValidator<GetRecipeRequest>
    {
        public GetRecipeValidator()
        {
            RuleFor(x => x.Id).Matches("(^([0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12})$)").WithMessage("Id must be a GUID");
            RuleFor(x => x.Nationality).MinimumLength(2);
        }
    }
}

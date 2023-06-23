using FluentValidation;

namespace Application.Features.RecipeFeatures.CreateRecipe
{
    public sealed class CreateRecipeValidator : AbstractValidator<CreateRecipeRequest>
    {
        public CreateRecipeValidator()
        {
            RuleFor(recipe => recipe.Name).NotEmpty().MinimumLength(2);
            RuleFor(recipe => recipe.Nationality).NotEmpty().MinimumLength(2);
            RuleFor(recipe => recipe.Url).NotEmpty();
                //.Matches(
                //    "/^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$/\r\n")
                //.WithMessage("Url must be a valid Url");
            RuleFor(recipe => recipe.Ingredients).NotEmpty();
        }
    }
}

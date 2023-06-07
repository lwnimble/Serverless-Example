using FluentValidation;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed class CreateIngredientValidator : AbstractValidator<CreateIngredientRequest>
    {
        public CreateIngredientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Category).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}

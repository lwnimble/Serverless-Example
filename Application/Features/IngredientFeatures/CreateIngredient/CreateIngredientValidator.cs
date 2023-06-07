using FluentValidation;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed class CreateIngredientValidator : AbstractValidator<CreateIngredientRequest>
    {
        public CreateIngredientValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}

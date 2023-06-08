using FluentValidation;

namespace Application.Features.IngredientFeatures.GetIngredient
{
    public sealed class GetIngredientValidator : AbstractValidator<GetIngredientRequest>
    {
        public GetIngredientValidator()
        {
            RuleFor(x => x.Category).MinimumLength(2);
            RuleFor(x => x.Id).Matches("(^([0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12})$)").WithMessage("Id must be a GUID");
        }
    }
}

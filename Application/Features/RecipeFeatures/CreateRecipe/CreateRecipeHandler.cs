using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.RecipeFeatures.CreateRecipe
{
    public sealed class CreateRecipeHandler : IRequestHandler<CreateRecipeRequest, RecipeDto>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateRecipeRequest> _validator;

        public CreateRecipeHandler(IRecipeRepository repository, IMapper mapper, IValidator<CreateRecipeRequest> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<RecipeDto> Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var recipe = _mapper.Map<Recipe>(request);

            if (string.IsNullOrEmpty(recipe.Id))
            {
                recipe.Id = Guid.NewGuid().ToString();
            }

            var createdRecipe = await _repository.Create(recipe);

            return _mapper.Map<RecipeDto>(createdRecipe);
        }
    }
}

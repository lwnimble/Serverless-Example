using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed class CreateIngredientHandler : IRequestHandler<CreateIngredientRequest, CreateIngredientResponse>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateIngredientRequest> _validator;

        public CreateIngredientHandler(IIngredientRepository repository, IMapper mapper, IValidator<CreateIngredientRequest> validator)
        {
            _ingredientRepository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateIngredientResponse> Handle(CreateIngredientRequest request, CancellationToken cancellationToken)
        { 
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            
            var ingredient = _mapper.Map<Ingredient>(request);

            if (string.IsNullOrEmpty(ingredient.Id))
            {
                ingredient.Id = Guid.NewGuid().ToString();
            }

            var createdIngredient = await _ingredientRepository.Create(ingredient);

            return _mapper.Map<CreateIngredientResponse>(createdIngredient);
        }
    }
}

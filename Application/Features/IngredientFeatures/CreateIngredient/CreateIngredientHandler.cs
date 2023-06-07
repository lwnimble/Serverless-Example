using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.IngredientFeatures.CreateIngredient
{
    public sealed class CreateIngredientHandler : IRequestHandler<CreateIngredientRequest, CreateIngredientResponse>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public CreateIngredientHandler(IIngredientRepository repository, IMapper mapper)
        {
            _ingredientRepository = repository;
            _mapper = mapper;
        }

        public async Task<CreateIngredientResponse> Handle(CreateIngredientRequest request, CancellationToken cancellationToken)
        {
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

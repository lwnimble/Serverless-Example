using Application.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.RecipeFeatures.GetRecipe
{
    public sealed class GetRecipeHandler : IRequestHandler<GetRecipeRequest, RecipeDto>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetRecipeRequest> _validator;

        public GetRecipeHandler(IRecipeRepository repository, IMapper mapper, IValidator<GetRecipeRequest> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<RecipeDto> Handle(GetRecipeRequest request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var recipe = await _repository.Get(request.Id, request.Nationality, cancellationToken);

            return _mapper.Map<RecipeDto>(recipe);
        }
    }
}

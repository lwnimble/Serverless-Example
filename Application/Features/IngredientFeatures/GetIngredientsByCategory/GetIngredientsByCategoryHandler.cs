using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.IngredientFeatures.GetIngredientsByCategory
{
    public sealed class GetIngredientsByCategoryHandler : IRequestHandler<GetIngredientsByCategoryRequest, List<IngredientDto>>
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetIngredientsByCategoryRequest> _validator;

        public GetIngredientsByCategoryHandler(IIngredientRepository repository, IMapper mapper,
            IValidator<GetIngredientsByCategoryRequest> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<IngredientDto>> Handle(GetIngredientsByCategoryRequest request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            
            var ingredients = await _repository.GetByCategory(request.CategoryName, cancellationToken);

            return _mapper.Map<List<IngredientDto>>(ingredients);
        }
    }
}

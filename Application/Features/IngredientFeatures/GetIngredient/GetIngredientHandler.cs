using Application.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.IngredientFeatures.GetIngredient
{
    public sealed class GetIngredientHandler : IRequestHandler<GetIngredientRequest, GetIngredientResponse>
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetIngredientRequest> _validator;

        public GetIngredientHandler(IIngredientRepository repository, IMapper mapper, IValidator<GetIngredientRequest> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetIngredientResponse> Handle(GetIngredientRequest request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var ingredient = await _repository.Get(request.Id, request.Category, cancellationToken);

            return _mapper.Map<GetIngredientResponse>(ingredient);
        }
    }
}

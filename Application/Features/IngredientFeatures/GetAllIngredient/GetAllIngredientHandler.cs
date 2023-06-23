using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IngredientFeatures.GetAllIngredient
{
    public sealed class GetAllIngredientHandler : IRequestHandler<GetAllIngredientRequest, List<IngredientDto>>
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public GetAllIngredientHandler(IIngredientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<IngredientDto>> Handle(GetAllIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredients = await _repository.GetAll(cancellationToken);

            return _mapper.Map<List<IngredientDto>>(ingredients);
        }
    }
}

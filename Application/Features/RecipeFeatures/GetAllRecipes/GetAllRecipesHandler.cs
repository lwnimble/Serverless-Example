using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.RecipeFeatures.GetAllRecipes
{
    public sealed class GetAllRecipesHandler : IRequestHandler<GetAllRecipesRequest, List<RecipeDto>>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        public GetAllRecipesHandler(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        } 

        public async Task<List<RecipeDto>> Handle(GetAllRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = await _repository.GetAll(cancellationToken);

            return _mapper.Map<List<RecipeDto>>(recipes);
        }
    }
}

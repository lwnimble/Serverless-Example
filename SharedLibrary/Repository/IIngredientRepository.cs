using Microsoft.Azure.Cosmos;
using SharedLibrary.Models;

namespace SharedLibrary.Repository
{
    public interface IIngredientRepository
    {
        public Task<ItemResponse<Ingredient>> CreateProductAsync(Ingredient ingredient);
    }
}

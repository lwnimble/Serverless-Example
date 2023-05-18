using Microsoft.Azure.Cosmos;
using SharedLibrary.Models;

namespace SharedLibrary.Repository
{
    public interface IIngredientRepository
    {
        public Task<Ingredient> AddIngredient(Ingredient ingredient);

        public Task<List<Ingredient>> GetAllIngredients();
    }
}

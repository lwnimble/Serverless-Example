using SharedLibrary.Models;

namespace SharedLibrary.Repository
{
    public interface IRecipeRepository
    {
        public Task<Recipe> AddRecipe(Recipe recipe);
        public Task<Recipe> UpdateRecipe(Recipe recipe);
        public Task<List<Recipe>> GetAllRecipes();
        public Task<Recipe?> GetRecipe(string id, string nationality);
    }
}

using Grocery.Core.Models;

namespace Grocery.Core.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task CreateCategoryAsync(string name);
    Task UpdateCategoryAsync(int id, string name);
    Task DeleteCategoryAsync(int id);
}
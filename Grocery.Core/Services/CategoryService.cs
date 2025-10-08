using Grocery.Core.Models;
using Grocery.Core.Repositories; //  Interface zit in Grocery.Core.Repositories
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grocery.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        => await _repository.GetAllAsync();

    public async Task<Category?> GetCategoryByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task CreateCategoryAsync(string name)
    {
        var category = new Category { Name = name };
        await _repository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(int id, string name)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing != null)
        {
            existing.Name = name;
            await _repository.UpdateAsync(existing);
        }
    }

    public async Task DeleteCategoryAsync(int id)
        => await _repository.DeleteAsync(id);
}

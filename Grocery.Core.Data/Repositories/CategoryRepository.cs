using Grocery.Core.Models;
using Grocery.Core.Repositories; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Core.Data.Repositories;

public class CategoryRepository : ICategoryRepository //  implementeert de interface
{
    private static List<Category> _categories = new()
    {
        new Category { Id = 1, Name = "Fruit" },
        new Category { Id = 2, Name = "Melkproducten" }
    };

    private static int _nextId = 3;

    public async Task<IEnumerable<Category>> GetAllAsync()
        => await Task.FromResult(_categories.AsEnumerable());

    public async Task<Category?> GetByIdAsync(int id)
        => await Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));

    public async Task AddAsync(Category category)
    {
        category.Id = _nextId++;
        _categories.Add(category);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Category category)
    {
        var existing = _categories.FirstOrDefault(c => c.Id == category.Id);
        if (existing != null)
        {
            existing.Name = category.Name;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            _categories.Remove(category);
        }
        await Task.CompletedTask;
    }
}
using Grocery.Core.Models;
using Grocery.Core.Repositories; //  using toevoegen
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Core.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private static List<ProductCategory> _productCategories = new();
    private static int _nextId = 1;

    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        => await Task.FromResult(_productCategories.AsEnumerable());

    public async Task<ProductCategory?> GetByIdAsync(int id)
        => await Task.FromResult(_productCategories.FirstOrDefault(pc => pc.Id == id));

    public async Task AddAsync(ProductCategory productCategory)
    {
        productCategory.Id = _nextId++;
        _productCategories.Add(productCategory);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var pc = _productCategories.FirstOrDefault(x => x.Id == id);
        if (pc != null)
        {
            _productCategories.Remove(pc);
        }
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<ProductCategory>> GetByProductIdAsync(int productId)
        => await Task.FromResult(_productCategories.Where(pc => pc.ProductId == productId).AsEnumerable());

    public async Task<IEnumerable<ProductCategory>> GetByCategoryIdAsync(int categoryId)
        => await Task.FromResult(_productCategories.Where(pc => pc.CategoryId == categoryId).AsEnumerable());
}
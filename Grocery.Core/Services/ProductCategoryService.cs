using Grocery.Core.Models;
using Grocery.Core.Repositories; // 👈Interface zit in Grocery.Core.Repositories
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Core.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryService(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task AddProductToCategoryAsync(int productId, int categoryId)
    {
        // Controleer of koppeling al bestaat
        var existing = await _repository.GetByProductIdAsync(productId);
        if (existing.Any(pc => pc.CategoryId == categoryId))
            return; // Al gekoppeld

        var productCategory = new ProductCategory
        {
            ProductId = productId,
            CategoryId = categoryId
        };
        await _repository.AddAsync(productCategory);
    }

    public async Task RemoveProductFromCategoryAsync(int productId, int categoryId)
    {
        var productCategories = await _repository.GetByProductIdAsync(productId);
        var toRemove = productCategories.FirstOrDefault(pc => pc.CategoryId == categoryId);
        if (toRemove != null)
        {
            await _repository.DeleteAsync(toRemove.Id);
        }
    }

    public async Task<IEnumerable<ProductCategory>> GetCategoriesForProductAsync(int productId)
        => await _repository.GetByProductIdAsync(productId);

    public async Task<IEnumerable<ProductCategory>> GetProductsInCategoryAsync(int categoryId)
        => await _repository.GetByCategoryIdAsync(categoryId);
}
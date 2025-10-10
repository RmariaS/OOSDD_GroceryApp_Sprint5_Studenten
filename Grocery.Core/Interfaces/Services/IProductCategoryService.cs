using Grocery.Core.Models;

namespace Grocery.Core.Services;

public interface IProductCategoryService
{
    Task AddProductToCategoryAsync(int productId, int categoryId);
    Task RemoveProductFromCategoryAsync(int productId, int categoryId);
    Task<IEnumerable<ProductCategory>> GetCategoriesForProductAsync(int productId);
    Task<IEnumerable<ProductCategory>> GetProductsInCategoryAsync(int categoryId);
}
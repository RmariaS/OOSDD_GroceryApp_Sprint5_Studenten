using Grocery.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories;

public interface IProductCategoryRepository
{
    Task<IEnumerable<ProductCategory>> GetAllAsync();
    Task<ProductCategory?> GetByIdAsync(int id);
    Task AddAsync(ProductCategory productCategory);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductCategory>> GetByProductIdAsync(int productId);
    Task<IEnumerable<ProductCategory>> GetByCategoryIdAsync(int categoryId);
}
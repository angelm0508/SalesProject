using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IProductDomain
    {
        #region async methods
        Task<bool> InsertAsync(Product obj);
        Task<bool> UpdateAsync(string sku, Product obj);
        Task<bool> DeleteAsync(string sku);
        Task<Product> GetBySkuAsync(string sku);
        Task<Product> GetByNameAsync(string name);
        Task<IQueryable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllThatContainsNameAsync(string name);
        Task<IEnumerable<Product>> GetAllThatContainsSkuAsync(string sku);
        Task<IQueryable<Product>> GetAllWithPagingAsync();
        #endregion
    }
}

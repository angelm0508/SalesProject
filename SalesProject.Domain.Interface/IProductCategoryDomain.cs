using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IProductCategoryDomain
    {
        #region async methods
        Task<bool> InsertAsync(ProductCategory obj);
        Task<bool> UpdateAsync(int id, ProductCategory obj);
        Task<bool> DeleteAsync(int id);
        Task<ProductCategory> GetByIdAsync(int id);
        Task<IEnumerable<ProductCategory>> GetAllThatContainsNameAsync(string name);
        Task<IQueryable<ProductCategory>> GetAllAsync();
        Task<IQueryable<ProductCategory>> GetAllWithPagingAsync();

        #region validations 
        Task<bool> RegisterExist(ProductCategory obj);
        #endregion
        #endregion
    }
}

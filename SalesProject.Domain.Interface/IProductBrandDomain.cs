using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IProductBrandDomain
    {
        #region async methods
        Task<bool> InsertAsync(ProductBrand obj);
        Task<bool> UpdateAsync(int id, ProductBrand obj);
        Task<bool> DeleteAsync(int id);
        Task<ProductBrand> GetByIdAsync(int id);
        Task<ProductBrand> GetByNameAsync(string name);
        Task<IQueryable<ProductBrand>> GetAllAsync();
        Task<IQueryable<ProductBrand>> GetAllWithPagingAsync();
        Task<IEnumerable<ProductBrand>> GetAllThatContainsNameAsync(string name);
        #endregion
    }
}

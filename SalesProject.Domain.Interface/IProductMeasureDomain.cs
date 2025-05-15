using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IProductMeasureDomain
    {
         #region async methods
        Task<bool> InsertAsync(ProductMeasure obj);
        Task<bool> UpdateAsync(int id, ProductMeasure obj);
        Task<bool> DeleteAsync(int id);
        Task<ProductMeasure> GetByIdAsync(int id);
        Task<IEnumerable<ProductMeasure>> GetAllThatContainsNameAsync(string name);
        Task<IQueryable<ProductMeasure>> GetAllAsync();
        Task<IQueryable<ProductMeasure>> GetAllWithPagingAsync();

        #region validations
        Task<bool> RegisterExist(string name);
        #endregion
        #endregion
    }
}

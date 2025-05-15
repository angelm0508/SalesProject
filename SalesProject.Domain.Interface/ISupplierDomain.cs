using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ISupplierDomain
    {
        #region async methods
        Task<bool> InsertAsync(Supplier obj);
        Task<bool> UpdateAsync(string code, Supplier obj);
        Task<bool> DeleteAsync(string code);
        Task<Supplier> GetByCodeAsync(string code);
        Task<Supplier> GetByNameAsync(string name);
        Task<IQueryable<Supplier>> GetAllAsync();
        Task<IQueryable<Supplier>> GetAllWithPagingAsync();
        Task<IEnumerable<Supplier>> GetAllTthatContainsNameAsync(string name);
        Task<IEnumerable<Supplier>> GetAllThatContainsNitAsync(string nit);

        #region validations
        Task<bool> ExistSupplier(string code);
        #endregion
        #endregion
    }
}

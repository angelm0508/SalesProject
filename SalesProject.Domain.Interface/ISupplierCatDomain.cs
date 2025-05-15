using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ISupplierCatDomain
    {
        #region async methods
        Task<bool> InsertAsync(SupplierCategory obj);
        Task<bool> UpdateAsync(int id, SupplierCategory obj);
        Task<bool> DeleteAsync(int id);
        Task<SupplierCategory> GetByIdAsync(int id);
        Task<SupplierCategory> GetByNameAsync(string name);
        Task<IEnumerable<SupplierCategory>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<SupplierCategory>> GetAllAsync();
        #endregion
    }
}

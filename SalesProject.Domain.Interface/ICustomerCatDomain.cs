using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ICustomerCatDomain
    {
        #region async methods
        Task<bool> InsertAsync(CustomerCategory obj);
        Task<bool> UpdateAsync(int id, CustomerCategory obj);
        Task<bool> DeleteAsync(int id);
        Task<CustomerCategory> GetByIdAsync(int id);
        Task<CustomerCategory> GetByNameAsync(string name);
        Task<IEnumerable<CustomerCategory>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<CustomerCategory>> GetAllAsync();
        #endregion
    }
}

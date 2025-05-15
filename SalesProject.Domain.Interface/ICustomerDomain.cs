using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region async methods
        Task<bool> InsertAsync(Customer obj);
        Task<bool> UpdateAsync(string code, Customer obj);
        Task<bool> DeleteAsync(string code);
        Task<Customer> GetByCodeAsync(string code);
        Task<Customer> GetByNameAsync(string name);
        Task<IQueryable<Customer>> GetAllAsync();
        Task<IQueryable<Customer>> GetAllWithPagingAsync();
        Task<IEnumerable<Customer>> GetAllTthatContainsNameAsync(string name);
        #region validations
        Task<bool> ExistCustomerCode(string code);
        #endregion
        #endregion
    }
}

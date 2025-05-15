using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ISaleReturnDomain
    {
        #region async methods
        Task<bool> InsertAsync(SaleReturn obj);
        Task<bool> UpdateAsync(int id, SaleReturn obj);
        Task<bool> CancelAsync(int id);
        Task<SaleReturn> GetByIdAsync(int id);
        Task<IQueryable<SaleReturn>> GetAllAsync();
        Task<IQueryable<SaleReturn>> GetAllWithPagingAsync();

        #region validations
        Task<bool> IsASaleReturnDocument(int id);
        Task<bool> IsCanceled(int id);
        Task<bool> RegisterExists(SaleReturn obj);
        #endregion
        #endregion
    }
}

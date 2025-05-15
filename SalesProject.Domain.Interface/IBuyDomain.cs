using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IBuyDomain
    {
        #region async methods
        Task<bool> InsertAsync(Buy obj);
        Task<bool> UpdateAsync(int id, Buy obj);
        Task<bool> CancelAsync(int id);
        Task<Buy> GetByIdAsync(int id);
        Task<IQueryable<Buy>> GetAllAsync();
        Task<IQueryable<Buy>> GetAllWithPagingAsync();

        #region validations
        Task<bool> IsABuyDocument(int id);
        Task<bool> RegisterExists(Buy obj);
        Task<bool> IsCanceled(int id);
        #endregion
        #endregion
    }
}

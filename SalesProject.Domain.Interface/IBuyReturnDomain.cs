using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IBuyReturnDomain
    {
        #region async methods
        Task<bool> InsertAsync(BuyReturn obj);
        Task<bool> UpdateAsync(int id, BuyReturn obj);
        Task<bool> CancelAsync(int id);
        Task<BuyReturn> GetByIdAsync(int id);
        Task<IQueryable<BuyReturn>> GetAllAsync();
        Task<IQueryable<BuyReturn>> GetAllWithPagingAsync();
        #region validations
        Task<bool> IsABuyReturnDocument(int id);
        Task<bool> RegisterExists(BuyReturn obj);
        Task<bool> IsCanceled(int id);
        #endregion
        #endregion
    }
}

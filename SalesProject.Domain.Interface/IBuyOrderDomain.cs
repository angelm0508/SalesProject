using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IBuyOrderDomain
    {
        #region async methods
        Task<bool> InsertAsync(BuyOrder obj);
        Task<bool> UpdateAsync(int id, BuyOrder obj);
        Task<bool> CancelAsync(int id);
        Task<BuyOrder> GetByIdAsync(int id);
        Task<IQueryable<BuyOrder>> GetAllAsync();
        Task<IQueryable<BuyOrder>> GetAllWithPagingAsync();

        #region validations
        Task<bool> IsCanceled(int id);
        Task<bool> IsABuyDocument(int id);
        Task<bool> RegisterExists(BuyOrder obj);
        Task<bool> HasBuyGenerated(int id);
        Task<bool> IsABuyOrderDocument(int id);
        Task<bool> GenerateBuyBasedOnBuyOrder(Buy obj);
        #endregion

        #endregion
    }
}

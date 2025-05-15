using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ISaleOrderDomain
    {
        #region async methods
        Task<bool> InsertAsync(SaleOrder obj);
        Task<bool> UpdateAsync(int id, SaleOrder obj);
        Task<bool> CancelAsync(int id);
        Task<SaleOrder> GetByIdAsync(int id);
        Task<IQueryable<SaleOrder>> GetAllAsync();
        Task<IQueryable<SaleOrder>> GetAllWithPagingAsync();
        Task<bool> GenerateSaleBasedOnSaleOrder(Sale obj);

        #region validations
        Task<bool> IsCanceled(int id);
        Task<bool> RegisterExists(SaleOrder obj);
        Task<bool> HasSaleGenerated(int id);
        Task<bool> IsAOutputSaleDocument(int id);
        Task<bool> IsASaleOrderDocument(int id);
        #endregion
        #endregion
    }
}

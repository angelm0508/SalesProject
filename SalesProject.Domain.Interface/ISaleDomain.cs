using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ISaleDomain
    {
        #region async methods
        Task<bool> InsertAsync(Sale obj);
        Task<bool> UpdateAsync(int id, Sale obj);
        Task<bool> CancelAsync(int id);
        Task<Sale> GetByIdAsync(int id);
        Task<IQueryable<Sale>> GetAllAsync();
        Task<IQueryable<Sale>> GetAllWithPagingAsync();


        #region validations
        Task<bool> IsCanceled(int id);
        Task<bool> IsASaleDocument(int id);
        Task<bool> RegisterExists(Sale obj);
        Task<bool> HasSaleReturnGenerated(int id);
        #endregion
        #endregion
    }
}

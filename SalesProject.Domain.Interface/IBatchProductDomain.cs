using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IBatchProductDomain
    {
        #region async methods
        Task<bool> InsertAsync(BatchProduct obj);
        Task<bool> UpdateAsync(string sku, int sysNumber, BatchProduct obj);
        Task<bool> DeleteAsync(string sku, int sysNumber);
        Task<BatchProduct> GetBySkuAndDistNumber(string sku, string distNumber);
        Task<IQueryable<BatchProduct>> GetAllAsync();
        #endregion
    }
}

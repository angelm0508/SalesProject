using SalesProject.Application.DTO.product.batch;
using SalesProject.Domain.Entity.Models;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IBatchProductApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(BatchProductCreateDTO obj);
        Task<Response<bool>> UpdateAsync(string sku, int sysNumber, BatchProductUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(string sku, int sysNumber);
        Task<Response<BatchProductDTO>> GetBySkuAndDistNumber(string sku, string distNumber);
        Task<Response<IEnumerable<BatchProductDTO>>> GetAllAsync();
        #endregion
    }
}

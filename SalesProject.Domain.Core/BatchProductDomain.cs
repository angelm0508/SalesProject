using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class BatchProductDomain : IBatchProductDomain
    {
        #region 
        private readonly IBatchGenericRepository<BatchProduct> _genericRepository;
        #endregion

        public BatchProductDomain(IBatchGenericRepository<BatchProduct> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region async methods
        public async Task<bool> InsertAsync(BatchProduct obj)
        {
            return await _genericRepository.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(string sku, int sysNumber, BatchProduct obj)
        {
            return await _genericRepository.UpdateAsync(sku, sysNumber, obj);
        }

        public async Task<bool> DeleteAsync(string sku, int sysNumber)
        {
            return await _genericRepository.DeleteAsync(sku,sysNumber);
        }

        public async Task<BatchProduct> GetBySkuAndDistNumber(string sku, string distNumber)
        {
            return await _genericRepository.GetBySkuAndDistNumber(sku, distNumber);
        }

        public async Task<IQueryable<BatchProduct>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }
        #endregion
    }
}

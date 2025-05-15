using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Domain.Core
{
    public class SaleReturnDomain : ISaleReturnDomain
    {

        public readonly IGenericRepository<SaleReturn> _genericSaleReturnRepo;
        public readonly IGenericRepositoryThree<Document> _genericDocumentRepo;

        public SaleReturnDomain(IGenericRepository<SaleReturn> genericRepository, 
            IGenericRepositoryThree<Document> genericDocumentRepo)
        {
            _genericSaleReturnRepo = genericRepository;
            _genericDocumentRepo = genericDocumentRepo;
        }
        public async Task<bool> InsertAsync(SaleReturn obj)
        {
            if (! await IsASaleReturnDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a sale return type document.");
            }
            if (string.IsNullOrEmpty(obj.Observation))
            {
                throw new Exception("The observation field must not be empty.");
            }
            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a sale return created with the same noDoc and Serie for this document.");
            }

            return await _genericSaleReturnRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, SaleReturn obj)
        {
            if (await IsCanceled(id))
            {
                throw new Exception($"This sale return is already canceled.");
            }
            return await _genericSaleReturnRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> CancelAsync(int id)
        {
            if (await IsCanceled(id))
            {
                throw new Exception($"This sale return is already canceled.");
            }

            return await _genericSaleReturnRepo.CancelAsync(id);
        }

        public Task<SaleReturn> GetByIdAsync(int id)
        {
            return _genericSaleReturnRepo.GetByIdAsync(id);
        }

        public async Task<IQueryable<SaleReturn>> GetAllAsync()
        {
            var queryable = await _genericSaleReturnRepo.GetAllAsync();
            return queryable;
        }

        public async Task<IQueryable<SaleReturn>> GetAllWithPagingAsync()
        {
            return await _genericSaleReturnRepo.GetAllAsync();
        }

        #region validations
        public async Task<bool> IsASaleReturnDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentTypeId == (int) Enumerators.DocumentTypes.DevolucionVenta;
        }

        public async Task<bool> RegisterExists(SaleReturn obj)
        {
            var queryable = await _genericSaleReturnRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie
                            && x.DocumentId == obj.DocumentId);
        }

        public async Task<bool> IsCanceled(int id)
        {
            var saleReturn = await GetByIdAsync(id);

            return saleReturn.TransStateId == (int) Enumerators.TransactionStates.Cancelado;
        }
        #endregion

    }
}

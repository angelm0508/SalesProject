using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Domain.Core
{
    public class BuyDomain : IBuyDomain
    {

        private readonly IGenericRepository<Buy> _genericBuyRepo;
        private readonly IGenericRepositoryThree<Document> _genericDocumentRepo;

        public BuyDomain(IGenericRepository<Buy> genericRepository, IGenericRepositoryThree<Document> genericDocumentRepo)
        {
            _genericBuyRepo = genericRepository;
            _genericDocumentRepo = genericDocumentRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(Buy obj)
        {
            if (! await IsABuyDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a buy type document.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a buy with the same NoDoc and Serie for this document.");
            }

            return await _genericBuyRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, Buy obj)
        {
            if (await IsCanceled(id))
                throw new Exception($"This document is already canceled.");

            return await _genericBuyRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> CancelAsync(int id)
        {
            if (await IsCanceled(id))
                throw new Exception($"This document is already canceled.");

            return await _genericBuyRepo.CancelAsync(id);
        }
        public async Task<Buy> GetByIdAsync(int id)
        {
            return await _genericBuyRepo.GetByIdAsync(id);
        }
        public async Task<IQueryable<Buy>> GetAllAsync()
        {
            return await _genericBuyRepo.GetAllAsync();
        }

        public async Task<IQueryable<Buy>> GetAllWithPagingAsync()
        {
            return await _genericBuyRepo.GetAllAsync();
        }

        #region validations
        public async Task<bool> IsABuyDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Id == (int)Enumerators.DocumentTypes.Compra;
        }

        public async Task<bool> RegisterExists(Buy obj)
        {
            var queryable = await _genericBuyRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie && x.DocumentId == obj.DocumentId);
        }

        public async Task<bool> IsCanceled(int id)
        {
            var buy = await _genericBuyRepo.GetByIdAsync(id);

            return buy.TransStateId == (int) Enumerators.TransactionStates.Cancelado;
        }
        #endregion
        #endregion
    }
}

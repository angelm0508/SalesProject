using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Domain.Core
{
    public class BuyReturnDomain : IBuyReturnDomain
    {

        private readonly IGenericRepository<BuyReturn> _genericBuyReturnRepo;
        private readonly IGenericRepositoryThree<Document> _genericDocumentRepo;

        public BuyReturnDomain(IGenericRepository<BuyReturn> genericRepository, 
            IGenericRepositoryThree<Document> genericDocumentRepo)
        {
            _genericBuyReturnRepo = genericRepository;
            _genericDocumentRepo = genericDocumentRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(BuyReturn obj)
        {
            if (!await IsABuyReturnDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a buy return type document.");
            }

            if (string.IsNullOrEmpty(obj.Observation))
            {
                throw new Exception("The observation field must not be empty.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a buy return created with the same noDoc and Serie for this document.");
            }

            return await _genericBuyReturnRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, BuyReturn obj)
        {
            if (!await IsCanceled(id))
                throw new Exception("Can't be updated, this buy return is already canceled.");

            return await _genericBuyReturnRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> CancelAsync(int id)
        {
            if (!await IsCanceled(id))
                throw new Exception("Can't be cancel, this buy return is already canceled.");

            return await _genericBuyReturnRepo.CancelAsync(id);
        }
        public async Task<BuyReturn> GetByIdAsync(int id)
        {
            return await _genericBuyReturnRepo.GetByIdAsync(id);
        }
        public async Task<IQueryable<BuyReturn>> GetAllAsync()
        {
            return await _genericBuyReturnRepo.GetAllAsync();
        }
        public async Task<IQueryable<BuyReturn>> GetAllWithPagingAsync()
        {
            return await _genericBuyReturnRepo.GetAllAsync();
        }

        #region validations
        public async Task<bool> IsABuyReturnDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Id == (int) Enumerators.DocumentTypes.DevolucionCompra;
        }
        public async Task<bool> RegisterExists(BuyReturn obj)
        {
            var queryable = await _genericBuyReturnRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie
                                            && x.DocumentId == obj.DocumentId);
        }

        public async Task<bool> IsCanceled(int id)
        {
            var buyReturn = await GetByIdAsync(id);

            return buyReturn.TransStateId == (int) Enumerators.TransactionStates.Cancelado;
        }
        #endregion



        #endregion
    }
}

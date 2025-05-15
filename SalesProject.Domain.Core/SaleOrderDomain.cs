using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Domain.Core
{
    public class SaleOrderDomain : ISaleOrderDomain
    {

        public readonly IGenericRepository<SaleOrder> _genericSaleOrderRepo;
        public readonly IGenericRepositoryThree<Document> _genericDocumentRepo;
        public readonly IGenericRepository<Sale> _genericSaleRepo;

        public SaleOrderDomain(IGenericRepository<SaleOrder> genericSaleOrderRepo,
                                IGenericRepositoryThree<Document> genericDocumentRepo,
                                IGenericRepository<Sale> genericSaleRepo
                                )
        {
            _genericSaleOrderRepo = genericSaleOrderRepo;
            _genericDocumentRepo = genericDocumentRepo;
            _genericSaleRepo = genericSaleRepo;

        }

        #region async methods
        public async Task<bool> InsertAsync(SaleOrder obj)
        {
            if (! await IsASaleOrderDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a sale order type document.");
            }

            if (!await IsAOutputSaleDocument(obj.OutputDocumentId))
            {
                throw new Exception("The output document is not for a sale type document.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a sale order register with the same NoDoc and Serie for this document.");
            }

            return await _genericSaleOrderRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, SaleOrder obj)
        {
            if (await IsCanceled(id))
            {
                throw new Exception("This sale order is already canceled.");
            }
            if (await HasSaleGenerated(id))
            {
                throw new Exception("There is a sale generated from this sale order. Please delete it first and try again.");
            }

            return await _genericSaleOrderRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> CancelAsync(int id)
        {
            if (await IsCanceled(id))
            {
                throw new Exception("This sale order is already canceled.");
            }
            if (await HasSaleGenerated(id))
            {
                throw new Exception("There is a sale generated from this sale order. Please delete it first and try again.");
            }
            return await _genericSaleOrderRepo.CancelAsync(id);
        }
        public async Task<SaleOrder> GetByIdAsync(int id)
        {
            return await _genericSaleOrderRepo.GetByIdAsync(id);
        }
        public async Task<IQueryable<SaleOrder>> GetAllAsync()
        {
            return await _genericSaleOrderRepo.GetAllAsync();
        }

        public async Task<IQueryable<SaleOrder>> GetAllWithPagingAsync()
        {
            return await _genericSaleOrderRepo.GetAllAsync();
        }

        public async Task<bool> GenerateSaleBasedOnSaleOrder(Sale obj)
        {
            if (await HasSaleGenerated((int)obj.SaleOrderId))
            {
                throw new Exception("There is already a sale created with this sale order id.");
            }

            return await _genericSaleRepo.InsertAsync(obj);
        }

        #region validations
        public async Task<bool> IsCanceled(int id)
        {
            var saleOrder = await GetByIdAsync(id);

            return saleOrder.TransStateId == (int)Enumerators.TransactionStates.Cancelado;
        }

        public async Task<bool> RegisterExists(SaleOrder obj)
        {
            var queryable = await _genericSaleOrderRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie 
                                        && x.DocumentId == obj.DocumentId);
        }
        public async Task<bool> HasSaleGenerated(int id)
        {
            var queryable = await _genericSaleRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.SaleOrderId == id);
        }

        public async Task<bool> IsASaleOrderDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentTypeId == (int) Enumerators.DocumentTypes.Cotizacion;
        }
        public async Task<bool> IsAOutputSaleDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentTypeId == (int) Enumerators.DocumentTypes.Venta;
        }
        
        #endregion

        #endregion
    }
}

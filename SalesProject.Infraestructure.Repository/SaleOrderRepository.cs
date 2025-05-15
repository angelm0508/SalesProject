using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Infraestructure.Repository
{
    public class SaleOrderRepository : IGenericRepository<SaleOrder>
    {
        private readonly ApiDbContext _context;
        public SaleOrderRepository(ApiDbContext context)
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(SaleOrder obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            await _context.SaleOrders.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }
        public async Task<bool> UpdateAsync(int id, SaleOrder obj)
        {
            var saleOrder = await _context.SaleOrders.SingleOrDefaultAsync(x => x.Id == id);

            saleOrder.OutputDocumentId = obj.OutputDocumentId;
            saleOrder.DateTrans = obj.DateTrans;
            saleOrder.Credit = obj.Credit;
            saleOrder.CreditDays = obj.CreditDays;

            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> CancelAsync(int id)
        {
            var saleOrder = await _context.SaleOrders.SingleOrDefaultAsync(x => x.Id == id);

            saleOrder.TransStateId = (int) Enumerators.TransactionStates.Cancelado;

            int canceled = await _context.SaveChangesAsync();

            return canceled > 0;
        }
        public async Task<SaleOrder> GetByIdAsync(int id)
        {
            return await _context.SaleOrders.Include(x => x.Document)
                                            .Include(x => x.CustomerCodeNavigation)
                                            .Include(x => x.UserCodeNavigation)
                                            .Include(x => x.TransState)
                                            .Include(x => x.OutputDocument)
                                            .Include(x => x.SaleOrderDets)
                                            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<SaleOrder>> GetAllAsync()
        {
            return  _context.SaleOrders.Include(x => x.Document)
                                        .Include(x => x.CustomerCodeNavigation)
                                        .Include(x => x.UserCodeNavigation)
                                        .Include(x => x.TransState)
                                        .Include(x => x.OutputDocument)
                                        .Include(x => x.SaleOrderDets);
        }
        #endregion

    }
}

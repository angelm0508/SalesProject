using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Infraestructure.Repository
{
    public class BuyOrderRepository : IGenericRepository<BuyOrder>
    {
        private readonly ApiDbContext _context;
        public BuyOrderRepository(ApiDbContext context) 
        {
            _context = new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(BuyOrder obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            await _context.BuyOrders.AddAsync(obj);
            int insert = await _context.SaveChangesAsync();

            return insert > 0;
        }
        public async Task<bool> UpdateAsync(int id, BuyOrder obj)
        {
            #region new logic
            var buyOrder = await _context.BuyOrders.SingleOrDefaultAsync(x => x.Id == id);

            buyOrder.OutputDocumentId = obj.OutputDocumentId;
            buyOrder.Credit = obj.Credit;
            buyOrder.CreditDays = obj.CreditDays;
            buyOrder.DateTrans = obj.DateTrans;

            var save = await _context.SaveChangesAsync();

            return save > 0;
            #endregion
        }
        public async Task<bool> CancelAsync(int id)
        {
            #region new logic
            var buyOrder = await _context.BuyOrders.SingleOrDefaultAsync(x => x.Id == id);

            buyOrder.TransStateId = (int) Enumerators.TransactionStates.Cancelado;

            var save = await _context.SaveChangesAsync();

            return save > 0;
            #endregion
        }
        public async Task<BuyOrder> GetByIdAsync(int id)
        {
            var buyOrder = await _context.BuyOrders.Include(x => x.TransState)
                                                    .Include(x => x.Document)
                                                    .Include(x => x.SupplierCodeNavigation)
                                                    .Include(x => x.UserCodeNavigation)
                                                    .Include(x => x.OutputDocument)
                                                    .Include(x => x.BuyOrderDets)
                                                    .FirstOrDefaultAsync(x => x.Id == id);

            return buyOrder;
        }

        public async Task<IQueryable<BuyOrder>> GetAllAsync()
        {
            IQueryable<BuyOrder> queryable = _context.BuyOrders.Include(x => x.TransState)
                                                                .Include(x => x.Document)
                                                                .Include(x => x.SupplierCodeNavigation)
                                                                .Include(x => x.UserCodeNavigation)
                                                                .Include(x => x.OutputDocument)
                                                                .Include(x => x.BuyOrderDets);
            return queryable;
        }
        #endregion

    }
}
using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class BuyRepisotory : IGenericRepository<Buy>
    {
        private readonly ApiDbContext _context;

        public BuyRepisotory(ApiDbContext context)
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(Buy obj)
        {
            string dateTrans = obj.DateTrans.ToString("yyyy-MM-dd");
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            object buyOrderId = (obj.BuyOrderId == 0) 
                                    ? null 
                                    : obj.BuyOrderId;

            var buyDetail = BuildBuyDetailString(obj.BuyDets);

            // Llamar al procedimiento almacenado con parámetros
            var insert = await _context.SPCRUDs
                                        .FromSqlInterpolated($@"
                                            EXEC sp_insert_buy 
                                            @supplierCode = {obj.SupplierCode}, 
                                            @documentId = {obj.DocumentId}, 
                                            @userCode = {obj.UserCode}, 
                                            @buyOrderId = {buyOrderId}, 
                                            @transStateId = {obj.TransStateId}, 
                                            @noDoc = {obj.NoDoc}, 
                                            @noSerie = {obj.Serie}, 
                                            @credit = {obj.Credit}, 
                                            @credit_days = {obj.CreditDays}, 
                                            @date = {date}, 
                                            @dateTrans = {dateTrans}, 
                                            @subTotal = {obj.SubTotal}, 
                                            @iva = {obj.Iva}, 
                                            @total = {obj.Total}, 
                                            @detail = {buyDetail}"
                                        )
                                        .ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);
            
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Buy obj)
        {
            #region new logic
            var buy = await _context.Buys.SingleOrDefaultAsync(x => x.Id == id);

            buy.DateTrans = obj.DateTrans;
            buy.Credit = obj.Credit;
            buy.CreditDays = obj.CreditDays;

            var updated = await _context.SaveChangesAsync();

            return updated > 0;
            #endregion
        }
        public async Task<bool> CancelAsync(int id)
        {
            #region new logic
            var cancel = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_cancel_buy {id};").ToListAsync();

            if (!string.IsNullOrEmpty(cancel[0].ErrorMessage))
                throw new Exception(cancel[0].ErrorMessage);

            return true;
            #endregion
        }
        public async Task<Buy> GetByIdAsync(int id)
        {
            return await _context.Buys.Include(x => x.TransState)
                                        .Include(x => x.Document)
                                        .Include(x => x.SupplierCodeNavigation)
                                        .Include(x => x.UserCodeNavigation)
                                        .Include(x => x.BuyDets)
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<Buy>> GetAllAsync()
        {
            return _context.Buys.Include(x => x.TransState)
                                .Include(x => x.Document)
                                .Include(x => x.SupplierCodeNavigation)
                                .Include(x => x.UserCodeNavigation)
                                .Include(x => x.BuyDets);
        }
        #endregion

        #region metodos propios
        private string BuildBuyDetailString(IEnumerable<BuyDet> detail)
        {
            string detailIntoString = "";
            for (int i=0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).ProductSku},{detail.ElementAt(i).Name}," +
                                $"{detail.ElementAt(i).Price},{detail.ElementAt(i).Units}," +
                                $"{detail.ElementAt(i).Discount},{detail.ElementAt(i).SubTotal},{detail.ElementAt(i).CellarCode}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion
    }
}

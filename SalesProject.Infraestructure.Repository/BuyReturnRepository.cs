using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class BuyReturnRepository : IGenericRepository<BuyReturn>
    {
        private readonly ApiDbContext _context;

        public BuyReturnRepository(ApiDbContext context)
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(BuyReturn obj)
        {
            string dateTrans = obj.DateTrans.ToString("yyyy-MM-dd");
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var returnSaleDet = BuildBuyDetailString(obj.BuyReturnDets);

            var insert = await _context.SPCRUDs
                                        .FromSqlInterpolated(
                                            $@"EXEC sp_insert_buy_return 
                                            @supplierCode='{obj.SupplierCode}', 
                                            @document_id={obj.DocumentId}, 
                                            @userCode='{obj.UserCode}', 
                                            @transStateId={obj.TransStateId}, 
                                            @noDoc={obj.NoDoc},
                                            @serie='{obj.Serie}',
                                            @credit= {obj.Credit}, 
                                            @dateTrans='{dateTrans}', 
                                            @date= '{date}', 
                                            @observation='{obj.Observation}', 
                                            @subtotal={obj.SubTotal}, 
                                            @iva={obj.Iva}, 
                                            @total={obj.Total}, 
                                            @detail='{returnSaleDet}'"
                                        ).ToListAsync();


            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);

            return true;
        }
        public async Task<bool> UpdateAsync(int id, BuyReturn obj)
        {
            #region new logic
            var buyReturn = await _context.BuyReturns.SingleOrDefaultAsync(x => x.Id == id);

            buyReturn.DateTrans = obj.DateTrans;
            buyReturn.Credit = obj.Credit;
            buyReturn.Observation = obj.Observation;

            int updated = await _context.SaveChangesAsync();

            return updated > 0;
            #endregion
        }
        public async Task<bool> CancelAsync(int id)
        {
            var canceled = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_cancel_buy_return @id={id};").ToListAsync();

            if (!string.IsNullOrEmpty(canceled[0].ErrorMessage))
                throw new Exception(canceled[0].ErrorMessage);

            return true;
        }
        public async Task<BuyReturn> GetByIdAsync(int id)
        {
            return await _context.BuyReturns.Include(x => x.TransState)
                                            .Include(x => x.Document)
                                            .Include(x => x.SupplierCodeNavigation)
                                            .Include(x => x.UserCodeNavigation)
                                            .Include(x => x.BuyReturnDets)
                                            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<BuyReturn>> GetAllAsync()
        {
            return _context.BuyReturns.Include(x => x.TransState)
                                        .Include(x => x.Document)
                                        .Include(x => x.SupplierCodeNavigation)
                                        .Include(x => x.UserCodeNavigation)
                                        .Include(x => x.BuyReturnDets);
        }
        #endregion

        #region metodos propios
        private string BuildBuyDetailString(IEnumerable<BuyReturnDet> detail)
        {
            string detailIntoString = "";
            for (int i = 0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).BuyId}, {detail.ElementAt(i).ProductSku}, {detail.ElementAt(i).Name}," +
                                $"{detail.ElementAt(i).Price}, {detail.ElementAt(i).Units}, {detail.ElementAt(i).Discount}," +
                                $"{detail.ElementAt(i).SubTotal}, {detail.ElementAt(i).CellarCode}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion

    }
}

using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Infraestructure.Repository
{
    public class SaleReturnRepository : IGenericRepository<SaleReturn>
    {
        private readonly ApiDbContext _context;
        public SaleReturnRepository(ApiDbContext context) 
        {
            _context = context;
        }


        #region async methods
        public async Task<bool> InsertAsync(SaleReturn obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            var detailIntoString = BuildBuyDetailString(obj.SaleReturnDets);

            var insert = await _context.SPCRUDs
                                        .FromSqlInterpolated(
                                            $@"EXEC sp_insert_sale_return 
                                            @customerCode= '{obj.CustomerCode}', 
                                            @document_id= {obj.DocumentId},
                                            @user_code= '{obj.UserCode}',
                                            @transStateId = {obj.TransStateId}, 
                                            @noDoc= {obj.NoDoc},
                                            @serie= '{obj.Serie}',
                                            @credit= {obj.Credit}, 
                                            @date_trans= {obj.DateTrans},
                                            @date= {obj.Date}, 
                                            @observation= '{obj.Observation}',
                                            @subtotal= {obj.SubTotal}, 
                                            @iva= {obj.Iva}, 
                                            @total= {obj.Total}, 
                                            @detail= '{detailIntoString}'"
                                        ).ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
            {
                throw new Exception(insert[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> UpdateAsync(int id, SaleReturn obj)
        {
            var saleReturn = await _context.SaleReturns.SingleOrDefaultAsync(x => x.Id == id);

            saleReturn.Credit = obj.Credit;
            saleReturn.DateTrans = obj.DateTrans;
            saleReturn.Observation = obj.Observation;

            int save = await _context.SaveChangesAsync();

            return save > 0;
        }
        public async Task<bool> CancelAsync(int id)
        {
            var cancel = await _context.SPCRUDs
                                        .FromSqlInterpolated(
                                            $@"EXEC sp_cancel_sale_return 
                                            @id= {id}"
                                        ).ToListAsync();

            if (cancel.Count > 0)
                throw new Exception(cancel[0].ErrorMessage);

            return true;
        }

        public async Task<SaleReturn> GetByIdAsync(int id)
        {
            return await _context.SaleReturns.Include(x => x.TransState)
                                                .Include(x => x.Document)
                                                .Include(x => x.CustomerCodeNavigation)
                                                .Include(x => x.UserCodeNavigation)
                                                .Include(x => x.SaleReturnDets)
                                                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<SaleReturn>> GetAllAsync()
        {
            return _context.SaleReturns.Include(x => x.TransState)
                                            .Include(x => x.Document)
                                            .Include(x => x.CustomerCodeNavigation)
                                            .Include(x => x.UserCodeNavigation)
                                            .Include(x => x.SaleReturnDets);
        }
        #endregion

        #region metodos propios
        private string BuildBuyDetailString(IEnumerable<SaleReturnDet> detail)
        {
            string detailIntoString = "";
            for (int i = 0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).SaleId},{detail.ElementAt(i).ProductSku},{detail.ElementAt(i).Name}," +
                                $"{detail.ElementAt(i).Price},{detail.ElementAt(i).Units},{detail.ElementAt(i).Discount}," +
                                $"{detail.ElementAt(i).SubTotal},{detail.ElementAt(i).CellarCode}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion
    }
}

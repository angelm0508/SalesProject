using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class SaleRepository : IGenericRepository<Sale>
    {
        private readonly ApiDbContext _context;
        public SaleRepository(ApiDbContext context)
        {
            _context = context;
        }
        #region 
        public async Task<bool> InsertAsync(Sale obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            string detailIntoString = BuildSaleDetailString(obj.SaleDets);

            var insert = await _context.SPCRUDs
                                        .FromSqlInterpolated($@"
                                            EXEC sp_insert_sale 
                                            @customerCode= '{obj.CustomerCode}',
                                            @documentId= {obj.DocumentId},
                                            @userCode= '{obj.UserCode}',
                                            @saleOrderId= {obj.SaleOrderId},
                                            @transStateId= {obj.TransStateId},
                                            @noDoc= {obj.NoDoc},
                                            @noSerie= '{obj.Serie}',
                                            @credit= {obj.Credit},
                                            @credit_days= {obj.CreditDays},
                                            @date= {obj.Date},
                                            @dateTrans= {obj.DateTrans},
                                            @subtotal= {obj.SubTotal},
                                            @iva= {obj.Iva}, 
                                            @total= {obj.Total}, 
                                            @detail = '{detailIntoString}' "
                                        )
                                        .ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);

            return true;
        }
        public async Task<bool> UpdateAsync(int id, Sale obj)
        {
            var sale = await _context.Sales.SingleOrDefaultAsync(x => x.Id == id);

            sale.DateTrans = obj.DateTrans;
            sale.Credit = obj.Credit;
            sale.CreditDays = obj.CreditDays;

            int save = await _context.SaveChangesAsync();

            return save > 0;
        }
        public async Task<bool> CancelAsync(int id)
        {
            var cancel = await _context.SPCRUDs
                                       .FromSqlInterpolated($@"
                                            EXEC sp_cancel_sale 
                                            @id = {id}"
                                       )
                                       .ToListAsync();

            if (!string.IsNullOrEmpty(cancel[0].ErrorMessage))
                throw new Exception(cancel[0].ErrorMessage);

            return true;
        }
        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _context.Sales.Include(x => x.TransState)
                                           .Include(x => x.Document)
                                           .Include(x => x.CustomerCodeNavigation)
                                           .Include(x => x.UserCodeNavigation)
                                           .Include(x => x.SaleDets)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<Sale>> GetAllAsync()
        {
            return  _context.Sales.Include(x => x.TransState)
                                    .Include(x => x.Document)
                                    .Include(x => x.CustomerCodeNavigation)
                                    .Include(x => x.UserCodeNavigation)
                                    .Include(x => x.SaleDets);
        }

        #region metodos propios
        private string BuildSaleDetailString(IEnumerable<SaleDet> detail)
        {
            string detailIntoString = "";
            for (int i = 0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).ProductSku},{detail.ElementAt(i).Name}," +
                                $"{detail.ElementAt(i).Price},{detail.ElementAt(i).Units}," +
                                $"{detail.ElementAt(i).Discount},{detail.ElementAt(i).SubTotal},{detail.ElementAt(i).CellarCode}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion

        #endregion
    }
}

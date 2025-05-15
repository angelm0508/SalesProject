using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class CellarTransferRepository : IGenericRepositoryThree<CellarTransfer>
    {
        private readonly ApiDbContext _context;

        public CellarTransferRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(CellarTransfer obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            string stringDetail = BuildTransferDetailString(obj.CellarTransferDets);

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
            {
                throw new Exception(insert[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> UpdateAsync(int id, CellarTransfer obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));

            string stringDetail = BuildTransferDetailString(obj.CellarTransferDets);

            var update = await _context.SPCRUDs.FromSqlInterpolated($"").ToListAsync();

            if (!string.IsNullOrEmpty(update[0].ErrorMessage))
            {
                throw new Exception(update[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_delete_cellar_trans @id={id}").ToListAsync();

            if (!string.IsNullOrEmpty(delete[0].ErrorMessage))
            {
                throw new Exception(delete[0].ErrorMessage);
            }

            return true;
        }

        public async Task<CellarTransfer> GetByIdAsync(int id)
        {
            return await _context.CellarTransfers.Include(x => x.CellarTransferDets)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<CellarTransfer>> GetAllAsync()
        {
            return _context.CellarTransfers.Include(x => x.CellarTransferDets);
        }

        #region aditional methods
        private string BuildTransferDetailString(ICollection<CellarTransferDet> detail)
        {
            string stringDetail = "";

            for (int i=0; i<detail.Count; i++)
            {
                stringDetail += $"{detail.ElementAt(i).ProductSku}, {detail.ElementAt(i).CellarOriginCode}," +
                    $"{detail.ElementAt(i).CellarDestinationCode}, {detail.ElementAt(i).Quantity}";

                stringDetail += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return stringDetail;
        }
        #endregion
    }
}

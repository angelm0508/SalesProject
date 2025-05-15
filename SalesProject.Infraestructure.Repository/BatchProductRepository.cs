using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class BatchProductRepository : IBatchGenericRepository<BatchProduct>
    {
        private readonly ApiDbContext _context;

        public BatchProductRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(BatchProduct obj)
        {
            await _context.BatchProducts.AddAsync(obj);
            var inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }

        public async Task<bool> UpdateAsync(string sku, int sysNumber, BatchProduct obj)
        {
            var batch = await _context.BatchProducts
                                            .SingleOrDefaultAsync( x =>
                                                x.Sku == sku 
                                                && x.SysNumber == sysNumber
                                            );

            batch.DistNumber = obj.DistNumber;
            batch.InDate = obj.InDate;
            batch.ExpDate = obj.ExpDate;
            batch.GrntStart = batch.GrntStart;
            batch.GrntExp = batch.GrntExp;
            batch.UpdateDate = DateTime.Now;
            batch.Status = obj.Status;
            batch.Details = obj.Details;

            var save = await _context.SaveChangesAsync();

            return save > 0;
        }
        public async Task<bool> DeleteAsync(string sku, int sysNumber)
        {
            var batch = await _context.BatchProducts
                                        .SingleOrDefaultAsync( x => 
                                            x.Sku == sku &&
                                            x.SysNumber == sysNumber
                                        );

            _context.BatchProducts.Remove(batch);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<BatchProduct> GetBySkuAndDistNumber(string sku, string distNumber)
        {
            return await _context.BatchProducts
                                    .FirstOrDefaultAsync(x =>
                                        x.Sku == sku &&
                                        x.DistNumber == distNumber
                                    );
        }
        

        public async Task<IQueryable<BatchProduct>> GetAllAsync()
        {
            return _context.BatchProducts.Include(x => x.SkuNavigation);
        }

    }
}


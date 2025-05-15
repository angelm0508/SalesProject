using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class MinMaxProductUnitsRepository : IGenericRepositoryThree<MinMaxProduct>
    {
        private readonly ApiDbContext _context;

        public MinMaxProductUnitsRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(MinMaxProduct obj)
        {
            await _context.MinMaxProducts.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }

        public async Task<bool> UpdateAsync(int id, MinMaxProduct obj)
        {
            var minMaxProductUnits = await _context.MinMaxProducts.SingleAsync(x => x.Id == id);

            // minMaxProductUnits.ProductSku = obj.ProductSku;
            minMaxProductUnits.CellarCode = obj.CellarCode;
            minMaxProductUnits.Minimum = obj.Minimum;
            minMaxProductUnits.Maximum = obj.Maximum;

            _context.MinMaxProducts.Update(minMaxProductUnits);
            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var minMaxProductUnits = await _context.MinMaxProducts.SingleAsync(x => x.Id == id);

            _context.MinMaxProducts.Remove(minMaxProductUnits);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<MinMaxProduct> GetByIdAsync(int id)
        {
            return await _context.MinMaxProducts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<MinMaxProduct>> GetAllAsync()
        {
            return _context.MinMaxProducts;
        }
    }
}

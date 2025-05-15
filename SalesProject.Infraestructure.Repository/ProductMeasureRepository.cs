using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductMeasureRepository : IGenericRepositoryThree<ProductMeasure>
    {
        private readonly ApiDbContext _context;

        public ProductMeasureRepository(ApiDbContext context)
        {
            _context = context;
        }
        #region async methods
        public async Task<bool> InsertAsync(ProductMeasure obj)
        {
            await _context.ProductMeasures.AddAsync(obj);
            int insert = await _context.SaveChangesAsync();

            return insert > 0;
        }

        public async Task<bool> UpdateAsync(int id, ProductMeasure obj)
        {
            var measure = await _context.ProductMeasures.SingleAsync(x => x.Id == id);

            measure.Name = obj.Name;

            _context.ProductMeasures.Update(measure);
            int update = await _context.SaveChangesAsync();

            return update > 0;  
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var measure = await _context.ProductMeasures.SingleAsync(x => x.Id == id);

            _context.ProductMeasures.Remove(measure);
            int delete = await _context.SaveChangesAsync();

            return delete > 0;
        }

        public async Task<ProductMeasure> GetByIdAsync(int id)
        {
            return await _context.ProductMeasures.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<ProductMeasure>> GetAllAsync()
        {
            return _context.ProductMeasures;
        }
        #endregion

    }
}

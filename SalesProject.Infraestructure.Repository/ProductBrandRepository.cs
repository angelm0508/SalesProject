using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductBrandRepository : IGenericRepositoryThree<ProductBrand>
    {
        private readonly ApiDbContext _context;

        public ProductBrandRepository(ApiDbContext context) 
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(ProductBrand obj)
        {
            await _context.ProductBrands.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }
        public async Task<bool> UpdateAsync(int id, ProductBrand obj)
        {
            var brand = await _context.ProductBrands.SingleOrDefaultAsync(x => x.Id == id);

            brand.Name = obj.Name;

            int updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _context.ProductBrands.SingleAsync(x => x.Id == id);
            
            _context.ProductBrands.Remove(brand);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<ProductBrand> GetByIdAsync(int id)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<ProductBrand>> GetAllAsync()
        {
            return _context.ProductBrands;
        }
        #endregion

    }
}

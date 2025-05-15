using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductRepository : IGenericRepositoryTwo<Product>
    {
        private readonly ApiDbContext _context;

        public ProductRepository(ApiDbContext context) 
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(Product obj)
        {
            await _context.Products.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }
        public async Task<bool> UpdateAsync(string sku, Product obj)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Sku == sku);

            product.Name = obj.Name;
            product.Description = obj.Description;
            product.BuyPrice = obj.BuyPrice;
            product.CategoryId = obj.CategoryId;
            product.MeasureId = obj.MeasureId;
            product.BrandId = obj.BrandId;
            product.StatusId = obj.StatusId;

            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(string sku)
        {
            var product = await _context.Products.SingleAsync(x => x.Sku == sku);

            _context.Products.Remove(product);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<Product> GetByCodeAsync(string sku)
        {
            return await _context.Products
                                    .Include(x => x.Category)
                                    .Include(x => x.Brand)
                                    .Include(x => x.Measure)
                                    .FirstOrDefaultAsync(x => x.Sku == sku);
        }
        public async Task<IQueryable<Product>> GetAllAsync()
        {
            return _context.Products
                            .Include(x => x.Status)
                            .Include(x => x.Brand)
                            .Include(x => x.Measure)
                            .Include(x => x.Status) 
                            .Include(x => x.Category); 
        }
        #endregion
    }
}

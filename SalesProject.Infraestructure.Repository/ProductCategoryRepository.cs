using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductCategoryRepository : IGenericRepositoryThree<ProductCategory>
    {
        private readonly ApiDbContext _context;

        public ProductCategoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(ProductCategory obj)
        {
            await _context.ProductCategories.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }

        public async Task<bool> UpdateAsync(int id, ProductCategory obj)
        {
            var category = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);

            category.Name = obj.Name;

            _context.ProductCategories.Update(category);
            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.ProductCategories.SingleAsync(x => x.Id == id);

            _context.ProductCategories.Remove(category);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _context.ProductCategories
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<ProductCategory>> GetAllAsync()
        {
            return _context.ProductCategories;
        }
    }
}

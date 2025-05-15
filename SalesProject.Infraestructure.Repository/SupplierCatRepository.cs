using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class SupplierCatRepository : IGenericRepositoryThree<SupplierCategory>
    {
        private readonly ApiDbContext _context;
        public SupplierCatRepository() 
        {
            _context= new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(SupplierCategory obj)
        {
            await _context.SupplierCategories.AddAsync(obj);
            var inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }
        public async Task<bool> UpdateAsync(int id, SupplierCategory obj)
        {
            var category = await _context.SupplierCategories.SingleOrDefaultAsync(x => x.Id == id);

            category.Description = obj.Description;
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.SupplierCategories.SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(category);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<SupplierCategory> GetByIdAsync(int id)
        {
            return await _context.SupplierCategories
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<SupplierCategory>> GetAllAsync()
        {
            return _context.SupplierCategories;
        }
        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class SupplierRepository : IGenericRepositoryTwo<Supplier>
    {
        private readonly ApiDbContext _context;
        public SupplierRepository() 
        {
            _context= new ApiDbContext();
        }
        #region async methods
        public async Task<bool> InsertAsync(Supplier obj)
        {
            await _context.Suppliers.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }
        public async Task<bool> UpdateAsync(string code, Supplier obj)
        {
            var supplier = await _context.Suppliers.SingleAsync(x => x.Code == code);

            supplier.Nit = obj.Nit;
            supplier.Name = obj.Name;
            supplier.Address = obj.Address;
            supplier.Phone = obj.Phone;
            supplier.CategoryId = obj.CategoryId;

            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(string code)
        {
            var supplier = await _context.Suppliers.SingleAsync(x => x.Code == code);

            _context.Remove(supplier);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<Supplier> GetByCodeAsync(string code)
        {
            return await _context.Suppliers
                                    .FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task<IQueryable<Supplier>> GetAllAsync()
        {
            return _context.Suppliers.Include(x => x.Category);
        }
        #endregion
    }
}

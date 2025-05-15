using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class CustomerCatRepository: IGenericRepositoryThree<CustomerCategory>
    {
        private readonly ApiDbContext _context;
        public CustomerCatRepository() 
        {
            _context= new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(CustomerCategory obj)
        {
            _context.CustomerCategories.AddAsync(obj);
            int insert = await _context.SaveChangesAsync();

            return insert > 0;
        }
        public async Task<bool> UpdateAsync(int id, CustomerCategory obj)
        {
            var category = await _context.CustomerCategories.FirstOrDefaultAsync(x => x.Id == id);

            category.Description = obj.Description;

            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.CustomerCategories.SingleAsync(x => x.Id == id);
            
            _context.CustomerCategories.Remove(customer);
            int delete = await _context.SaveChangesAsync();

            return delete > 0;
        }

        public async Task<CustomerCategory> GetByIdAsync(int id)
        {
            return await _context.CustomerCategories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<CustomerCategory>> GetAllAsync()
        {
            return _context.CustomerCategories;
        }
        
        #endregion

    }
}

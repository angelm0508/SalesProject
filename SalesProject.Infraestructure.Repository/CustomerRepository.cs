using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class CustomerRepository : IGenericRepositoryTwo<Customer>
    {
        private readonly ApiDbContext _context;
        public CustomerRepository() 
        {
            _context = new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(Customer obj)
        {
            await _context.Customers.AddAsync(obj);
            int insert = await _context.SaveChangesAsync();

            return insert > 0;
        }
        public async Task<bool> UpdateAsync(string code, Customer obj)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Code == code);

            customer.Nit = (!string.IsNullOrEmpty(obj.Nit)) ? obj.Nit : customer.Nit;
            customer.Cui = (!string.IsNullOrEmpty(obj.Cui)) ? obj.Cui : customer.Cui;
            customer.Name = (!string.IsNullOrEmpty(obj.Name)) ? obj.Name : customer.Name;
            customer.Address = (!string.IsNullOrEmpty(obj.Address)) ? obj.Address : customer.Address;
            customer.Phone = (!string.IsNullOrEmpty(obj.Phone)) ? obj.Phone : customer.Phone;
            customer.Email = (!string.IsNullOrEmpty(obj.Email)) ? obj.Email : customer.Email;
            customer.CreditDays = (obj.CreditDays != null) ? obj.CreditDays : customer.CreditDays;
            customer.CreditLimit = (obj.CreditLimit != null) ? obj.CreditLimit : customer.CreditLimit;
            customer.Defaulter = obj.Defaulter;
            customer.CategoryId = customer.CategoryId;

            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(string code)
        {
            var customer = await _context.Customers.SingleAsync(x => x.Code == code);

            _context.Customers.Remove(customer);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<Customer> GetByCodeAsync(string code)
        {
            return await _context.Customers.Include(x => x.Category).FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return _context.Customers.Include(x => x.Category);
        }
        #endregion
    }
}
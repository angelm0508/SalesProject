using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IGenericRepositoryTwo<Customer> _genericCustomerRepo;
        public CustomerDomain(IGenericRepositoryTwo<Customer> genericCustomerRepo)
        {
            _genericCustomerRepo = genericCustomerRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(Customer obj)
        {

            if (await ExistCustomerCode(obj.Code))
                throw new Exception($"There is already a customer created with the same code."); 

            return await _genericCustomerRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(string code, Customer obj)
        {
            return await _genericCustomerRepo.UpdateAsync(code, obj);
        }
        public Task<bool> DeleteAsync(string code)
        {
            return _genericCustomerRepo.DeleteAsync(code);
        }

        public async Task<Customer> GetByCodeAsync(string code)
        {
            return await _genericCustomerRepo.GetByCodeAsync(code);
        }

        public async Task<Customer> GetByNameAsync(string name)
        {
            var customerQueryable = await _genericCustomerRepo.GetAllAsync();
            var customer = customerQueryable.FirstOrDefault(x => x.Name.Equals(name));

            return customer;
        }

        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return await _genericCustomerRepo.GetAllAsync();
        }

        public async Task<IQueryable<Customer>> GetAllWithPagingAsync()
        {
            return await _genericCustomerRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllTthatContainsNameAsync(string name)
        {
            var customerQueryable = await _genericCustomerRepo.GetAllAsync();
            var customers = customerQueryable.Where(x => x.Name.Contains(name)).ToList();
            
            return customers;
        }

        #region validations
        public async Task<bool> ExistCustomerCode(string code)
        {
            var queryable = await _genericCustomerRepo.GetAllAsync();
            var exist = await queryable.AnyAsync(x => x.Code == code);

            return exist;
        }
        #endregion
        #endregion
    }
}
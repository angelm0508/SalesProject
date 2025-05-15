using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class CustomerCatDomain : ICustomerCatDomain
    {
        private readonly IGenericRepositoryThree<CustomerCategory> _genericCustomerCatRepo;
        public CustomerCatDomain(IGenericRepositoryThree<CustomerCategory> customerCatRepository) 
        {
            _genericCustomerCatRepo = customerCatRepository;
        }

        #region async methods
        public async Task<bool> InsertAsync(CustomerCategory obj)
        {
            if (await GetByNameAsync(obj.Description) != null)
            {
                throw new Exception("There is already a customer category created with the same name.");
            }
            return await _genericCustomerCatRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, CustomerCategory obj)
        {
            return await _genericCustomerCatRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericCustomerCatRepo.DeleteAsync(id);
        }

        public async Task<CustomerCategory> GetByIdAsync(int id)
        {
            return await _genericCustomerCatRepo.GetByIdAsync(id);
        }

        public async Task<CustomerCategory> GetByNameAsync(string name)
        {
            var queryable = await _genericCustomerCatRepo.GetAllAsync();
            var customerCat = await queryable.FirstOrDefaultAsync(x => x.Description == name);

            return customerCat;
        }

        public async Task<IQueryable<CustomerCategory>> GetAllAsync()
        {
            return await _genericCustomerCatRepo.GetAllAsync();
        }

        public async Task<IEnumerable<CustomerCategory>> GetAllTthatContainsNameAsync(string name)
        {
            var customerCats = await _genericCustomerCatRepo.GetAllAsync();
            return await customerCats.Where(x => x.Description.Contains(name)).ToListAsync();
        }
        #endregion
    }
}

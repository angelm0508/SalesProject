using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class SupplierCatDomain : ISupplierCatDomain
    {
        private readonly IGenericRepositoryThree<SupplierCategory> _genericSupplierCatRepo;
        public SupplierCatDomain(IGenericRepositoryThree<SupplierCategory> genericRepository) 
        {
            _genericSupplierCatRepo= genericRepository;
        }
        #region async methods
        public async Task<bool> InsertAsync(SupplierCategory obj)
        {
            if (await GetByNameAsync(obj.Description) != null)
            {
                throw new Exception("There is already a supplier category created with the same name.");
            }
            return await _genericSupplierCatRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, SupplierCategory obj)
        {
            return await _genericSupplierCatRepo.UpdateAsync(id, obj);    
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericSupplierCatRepo.DeleteAsync(id);
        }
        public async Task<SupplierCategory> GetByIdAsync(int id)
        {
            return await _genericSupplierCatRepo.GetByIdAsync(id);
        }
        public async Task<SupplierCategory> GetByNameAsync(string name)
        {
            var supplierCat = await _genericSupplierCatRepo.GetAllAsync();
            return await supplierCat.FirstOrDefaultAsync(x => x.Description == name);
        }

        public async Task<IQueryable<SupplierCategory>> GetAllAsync()
        {
            return await _genericSupplierCatRepo.GetAllAsync();
        }

        public async Task<IEnumerable<SupplierCategory>> GetAllTthatContainsNameAsync(string name)
        {
            var supplierCats = await _genericSupplierCatRepo.GetAllAsync();
            return await supplierCats.Where(x => x.Description.Contains(name)).ToListAsync();
        }
        
        #endregion
    }
}

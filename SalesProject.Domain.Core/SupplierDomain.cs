using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class SupplierDomain : ISupplierDomain
    {
        private readonly IGenericRepositoryTwo<Supplier> _genericSupplierRepo;
        public SupplierDomain(IGenericRepositoryTwo<Supplier> genericRepository) 
        {
            _genericSupplierRepo = genericRepository;
        }

        #region async methods
        public async Task<bool> InsertAsync(Supplier obj)
        {
            if (await ExistSupplier(obj.Code))
            {
                throw new Exception("There is already created a supplier with the same code.");
            }

            return await _genericSupplierRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(string code, Supplier obj)
        {
            return await _genericSupplierRepo.UpdateAsync(code, obj);
        }
        public async Task<bool> DeleteAsync(string code)
        {
            return await _genericSupplierRepo.DeleteAsync(code);
        }

        public async Task<Supplier> GetByCodeAsync(string code)
        {
            return await _genericSupplierRepo.GetByCodeAsync(code);
        }

        public async Task<Supplier> GetByNameAsync(string name)
        {
            var suppliers = await _genericSupplierRepo.GetAllAsync();

            return await suppliers.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<IQueryable<Supplier>> GetAllAsync()
        {
            return _genericSupplierRepo.GetAllAsync();
        }
        public Task<IQueryable<Supplier>> GetAllWithPagingAsync()
        {
            return _genericSupplierRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllThatContainsNitAsync(string nit)
        {
            var suppliers = await _genericSupplierRepo.GetAllAsync();

            return await suppliers.Where(
                                      x => x.Nit.Contains(nit)
                                  )
                                  .ToListAsync();
        }
        public async Task<IEnumerable<Supplier>> GetAllTthatContainsNameAsync(string name)
        {
            var suppliers = await _genericSupplierRepo.GetAllAsync();
            
            return await suppliers.Where(
                                        x => x.Name.Contains(name)
                                    )
                                  .ToListAsync();
        }

        #region validations
        public async Task<bool> ExistSupplier(string code)
        {
            var supplier = await GetByCodeAsync(code);

            return supplier != null;
        }
        #endregion
        #endregion
    }
}

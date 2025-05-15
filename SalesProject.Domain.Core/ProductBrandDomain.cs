using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class ProductBrandDomain : IProductBrandDomain
    {
        private readonly IGenericRepositoryThree<ProductBrand> _genericProductBrandRepo;

        public ProductBrandDomain(IGenericRepositoryThree<ProductBrand> genericProductBrandRepo) 
        {
            _genericProductBrandRepo = genericProductBrandRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(ProductBrand obj)
        {
            if (await GetByNameAsync(obj.Name) != null)
            {
                throw new Exception("There is already a product brand created with the same name.");
            }
            return await _genericProductBrandRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, ProductBrand obj)
        {
            if (await GetByNameAsync(obj.Name) != null)
            {
                throw new Exception("There is already a product brand created with the same name.");
            }

            return await _genericProductBrandRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id) 
        { 
            return await _genericProductBrandRepo.DeleteAsync(id);
        }
        public async Task<ProductBrand> GetByIdAsync(int id)
        {
            return await _genericProductBrandRepo.GetByIdAsync(id);
        }
        public async Task<ProductBrand> GetByNameAsync(string name)
        {
            var queryable = await _genericProductBrandRepo.GetAllAsync();
            return await queryable.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IQueryable<ProductBrand>> GetAllAsync()
        {
            return await _genericProductBrandRepo.GetAllAsync();
        }

        public async Task<IQueryable<ProductBrand>> GetAllWithPagingAsync()
        {
            return await _genericProductBrandRepo.GetAllAsync();
        }

        public async Task<IEnumerable<ProductBrand>> GetAllThatContainsNameAsync(string name)
        {
            var queryable = await _genericProductBrandRepo.GetAllAsync();
            return await queryable.Where(x => x.Name.Contains(name)).ToListAsync();
        }
        
        #endregion
    }
}

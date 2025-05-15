using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class ProductCategoryDomain : IProductCategoryDomain
    {
       
        private readonly IGenericRepositoryThree<ProductCategory> _genericProductCatRepo;

        public ProductCategoryDomain(IGenericRepositoryThree<ProductCategory> genericRepository)
        {
            _genericProductCatRepo = genericRepository;
        }
        public async Task<bool> InsertAsync(ProductCategory obj)
        {
            if (await RegisterExist(obj))
            {
                throw new Exception($"There is already register a product category with the same name.");
            }

            return await _genericProductCatRepo.InsertAsync(obj); 
        }
        public async Task<bool> UpdateAsync(int id, ProductCategory obj)
        {
            return await _genericProductCatRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericProductCatRepo.DeleteAsync(id);
        }
        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _genericProductCatRepo.GetByIdAsync(id);
        }

        public Task<IQueryable<ProductCategory>> GetAllAsync()
        {
            return _genericProductCatRepo.GetAllAsync();
        }
        public Task<IQueryable<ProductCategory>> GetAllWithPagingAsync()
        {
            return _genericProductCatRepo.GetAllAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllThatContainsNameAsync(string name)
        {
            var queryable = await _genericProductCatRepo.GetAllAsync();
            return await queryable.Where(x => x.Name.Contains(name)).ToListAsync();
        }


        #region validations
        public async Task<bool> RegisterExist(ProductCategory obj)
        {
            var queryable = await _genericProductCatRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.Name == obj.Name);
        }
        #endregion

    }
}

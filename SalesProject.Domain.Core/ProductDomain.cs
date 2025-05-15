using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;


namespace SalesProject.Domain.Core
{
    public class ProductDomain : IProductDomain
    {
        private readonly IGenericRepositoryTwo<Product> _genericProductRepo;
        public ProductDomain(IGenericRepositoryTwo<Product> genericProductRepo)
        {
            _genericProductRepo = genericProductRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(Product obj)
        {
            if (await GetBySkuAsync(obj.Sku) != null)
            {
                throw new Exception("There is already a product created with the same SKU.");
            }
            return await _genericProductRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(string sku, Product obj)
        {
            return await _genericProductRepo.UpdateAsync(sku, obj);  
        }
        public async Task<bool> DeleteAsync(string sku)
        {
            return await _genericProductRepo.DeleteAsync(sku);
        }

        public async Task<Product> GetBySkuAsync(string sku)
        {
            var queryable = await _genericProductRepo.GetAllAsync();
            var product = await queryable.FirstOrDefaultAsync(x => x.Sku == sku);

            return product;
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            var product = await _genericProductRepo.GetAllAsync();
            return await product.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<IQueryable<Product>> GetAllAsync()
        {
            return await _genericProductRepo.GetAllAsync();
        }

        public async Task<IQueryable<Product>> GetAllWithPagingAsync()
        {
            return await _genericProductRepo.GetAllAsync();
        }
        public async Task<IEnumerable<Product>> GetAllThatContainsNameAsync(string name)
        {
            var products = await _genericProductRepo.GetAllAsync();
            return await products.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllThatContainsSkuAsync(string sku)
        {
            var queryable = await _genericProductRepo.GetAllAsync();
            return await queryable.Where(x => x.Sku.Contains(sku)).ToListAsync();
        }
        #endregion
    }
}

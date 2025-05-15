using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class ProductMeasureDomain : IProductMeasureDomain
    {
        private readonly IGenericRepositoryThree<ProductMeasure> _genericMeasureRepo;

        public ProductMeasureDomain(IGenericRepositoryThree<ProductMeasure> genericRepository)
        {
            _genericMeasureRepo = genericRepository;
        }
        public async Task<bool> InsertAsync(ProductMeasure obj)
        {
            if (await RegisterExist(obj.Name))
            {
                throw new Exception("There is already created a measure with the same name.");
            }

            return await _genericMeasureRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, ProductMeasure obj)
        {
            if (await RegisterExist(obj.Name))
            {
                throw new Exception("There is already created a measure with the same name.");
            }

            return await _genericMeasureRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericMeasureRepo.DeleteAsync(id); 
        }

        public async Task<ProductMeasure> GetByIdAsync(int id)
        {
            return await _genericMeasureRepo.GetByIdAsync(id);
        }

        public async Task<IQueryable<ProductMeasure>> GetAllAsync()
        {
            return await _genericMeasureRepo.GetAllAsync();
        }

        public async Task<IQueryable<ProductMeasure>> GetAllWithPagingAsync()
        {
            return await _genericMeasureRepo.GetAllAsync();
        }

        public async Task<IEnumerable<ProductMeasure>> GetAllThatContainsNameAsync(string name)
        {
            var queryable = await _genericMeasureRepo.GetAllAsync();
            return await queryable.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        #region validations
        public async Task<bool> RegisterExist(string name)
        {
            var queryable = await _genericMeasureRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.Name == name);
        }
        #endregion

    }
}

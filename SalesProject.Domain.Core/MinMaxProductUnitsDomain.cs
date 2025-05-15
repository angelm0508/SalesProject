using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class MinMaxProductUnitsDomain : IMinMaxProductUnitsDomain
    {
        private readonly IGenericRepositoryThree<MinMaxProduct> _genericMinMaxProdsRepo;
        private readonly IGenericRepositoryTwo<Cellar> _genericCellarRepo;

        public MinMaxProductUnitsDomain(IGenericRepositoryThree<MinMaxProduct> genericMinMaxProdsRepo, 
                IGenericRepositoryTwo<Cellar> genericCellarRepo)
        {
            _genericMinMaxProdsRepo = genericMinMaxProdsRepo;
            _genericCellarRepo = genericCellarRepo;
        }

        public async Task<bool> InsertAsync(MinMaxProduct obj)
        {
            if (!await IsAValidCellarCode(obj.CellarCode))
            {
                throw new Exception("Please enter a valid cellar code.");
            }

            if (await RegisterExist(obj))
            {
                throw new Exception("There is already a min max register to this product and cellar.");
            }

            if (!AreManimumAndMaximumValid(obj.Minimum, obj.Maximum))
            {
                throw new Exception("Maximum must be grather than minimum value.");
            }

            return await _genericMinMaxProdsRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, MinMaxProduct obj)
        {
            if (!await IsAValidCellarCode(obj.CellarCode))
            {
                throw new Exception("Please enter a valid cellar code.");
            }

            if (! await RegisterToUpdateExist(id, obj))
            {
                throw new Exception("There is already a min max register to this product and cellar.");
            }

            if (!AreManimumAndMaximumValid(obj.Minimum, obj.Maximum))
            {
                throw new Exception("Maximum must be grather than minimum value.");
            }

            return await _genericMinMaxProdsRepo.UpdateAsync(id, obj);  
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericMinMaxProdsRepo.DeleteAsync(id);
        }

        public async Task<MinMaxProduct> GetByIdAsync(int id)
        {
            return await _genericMinMaxProdsRepo.GetByIdAsync(id);
        }
        
        public async Task<IQueryable<MinMaxProduct>> GetAllAsync()
        {
            return await _genericMinMaxProdsRepo.GetAllAsync();
        }

        public async Task<IQueryable<MinMaxProduct>> GetAllWithPagingAsync()
        {
            return await _genericMinMaxProdsRepo.GetAllAsync();
        }

        #region validations
        public async Task<bool> RegisterExist(MinMaxProduct obj)
        {
            var queryable = await _genericMinMaxProdsRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.ProductSku == obj.ProductSku && x.CellarCode == obj.CellarCode); 
        }

        public async Task<bool> RegisterToUpdateExist(int id, MinMaxProduct obj)
        {
            var queryable = await _genericMinMaxProdsRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.Id != id && x.ProductSku == obj.ProductSku && x.CellarCode == obj.CellarCode);
        }

        public async Task<bool> IsAValidCellarCode(string cellarId)
        {
            var cellar = await _genericCellarRepo.GetByCodeAsync(cellarId);
            return cellar != null;
        }

        public bool AreManimumAndMaximumValid(int min, int max)
        {
            return max > min;
        }
        #endregion
    }
}

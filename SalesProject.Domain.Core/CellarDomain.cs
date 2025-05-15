using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class CellarDomain : ICellarDomain
    {
        private readonly IGenericRepositoryTwo<Cellar> _genericCellarRepo;
        public CellarDomain(IGenericRepositoryTwo<Cellar> genericRepository) 
        {
            _genericCellarRepo = genericRepository;
        }
        #region async methods
        public async Task<bool> InsertAsync(Cellar obj)
        {
            if (await GetByNameAsync(obj.Name) != null)
            {
                throw new Exception("There is already a cellar created with the same name.");
            }
            return await _genericCellarRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(string code, Cellar obj)
        {
            return await _genericCellarRepo.UpdateAsync(code, obj);
        }
        public async Task<bool> DeleteAsync(string code)
        {
            return await _genericCellarRepo.DeleteAsync(code);
        }
        public async Task<Cellar> GetByCodeAsync(string code)
        {
            return await _genericCellarRepo.GetByCodeAsync(code);
        }

        public async Task<Cellar> GetByNameAsync(string name)
        {
            var queryable = await _genericCellarRepo.GetAllAsync();
            var cellar = await queryable.FirstOrDefaultAsync(x => x.Name == name);

            return cellar;
        }

        public async Task<IQueryable<Cellar>> GetAllAsync()
        {
            return await _genericCellarRepo.GetAllAsync();
        }
        #endregion
    }
}

using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ICellarDomain
    {
        #region async methods
        Task<bool> InsertAsync(Cellar obj);
        Task<bool> UpdateAsync(string code, Cellar obj);
        Task<bool> DeleteAsync(string code);
        Task<Cellar> GetByCodeAsync(string code);
        Task<Cellar> GetByNameAsync(string name);
        Task<IQueryable<Cellar>> GetAllAsync();
        #endregion
    }
}

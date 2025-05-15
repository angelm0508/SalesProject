using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IMinMaxProductUnitsDomain
    {
        #region async methods
        Task<bool> InsertAsync(MinMaxProduct obj);
        Task<bool> UpdateAsync(int id, MinMaxProduct obj);
        Task<bool> DeleteAsync(int id);
        Task<MinMaxProduct> GetByIdAsync(int id);
        Task<IQueryable<MinMaxProduct>> GetAllAsync();
        Task<IQueryable<MinMaxProduct>> GetAllWithPagingAsync();

        #region validations
        Task<bool> RegisterExist(MinMaxProduct obj);
        Task<bool> IsAValidCellarCode(string code);
        bool AreManimumAndMaximumValid(int min, int max);
        #endregion
        #endregion
    }
}

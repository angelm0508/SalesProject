using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface IAuthenticateDomain
    {
        #region async methods
        Task<string> AuthenticateAsync(UserSy obj);
        Task<bool> RegisterAsync(UserSy obj);
        Task<bool> UpdateAsync(string code, UserSy obj);
        Task<bool> DeleteAsync(string code);
        Task<UserSy> GetByCodeAsync(string code);
        Task<UserSy> GetByNameAsync(string name);
        Task<IQueryable<UserSy>> GetAllAsync();
        Task<IQueryable<UserSy>> GetAllWithPagingAsync();
        Task<IEnumerable<UserSy>> GetAllTthatContainsNameAsync(string name);
        #endregion

        #region sync methods
        string GenerateToken(UserSy obj);
        #endregion
    }
}

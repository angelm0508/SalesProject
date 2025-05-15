using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class AuthenticateRepository : IGenericRepositoryTwo<UserSy>
    {
        private readonly ApiDbContext _context;
        public AuthenticateRepository()
        {
            _context = new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(UserSy obj)
        {
            _context.UserSys.AddAsync(obj);
            int insert = await _context.SaveChangesAsync();

            return insert > 0;
        }

        public async Task<bool> UpdateAsync(string code, UserSy obj)
        {
            /*var user = await _context.UserSys.FirstOrDefaultAsync(x => x.Username == code);

            user. = obj.Description;

            var updated = await _context.SaveChangesAsync();
            return updated > 0;*/
            return true;
        }

        public async Task<bool> DeleteAsync(string code)
        {
            var user = await _context.UserSys.SingleAsync(x => x.Code == code);

            _context.UserSys.Remove(user);
            int delete = await _context.SaveChangesAsync();

            return delete > 0;
        }

        public async Task<UserSy> GetByCodeAsync(string code)
        {
            return await _context.UserSys.FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task<IQueryable<UserSy>> GetAllAsync()
        {
            return _context.UserSys;
        }

        #endregion
    }
}

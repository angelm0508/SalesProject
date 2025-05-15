using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class CellarRepository : IGenericRepositoryTwo<Cellar>
    {
        private readonly ApiDbContext _context;
        public CellarRepository() 
        {
            _context = new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(Cellar obj)
        {

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_insert_cellar @code={obj.Code}, @name={obj.Name}, @address={obj.Address}").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);

            return true;
        }
        public async Task<bool> UpdateAsync(string code, Cellar obj)
        {
            var cellar = await _context.Cellars.FirstOrDefaultAsync(x => x.Code == code);

            cellar.Name = obj.Name;
            cellar.Address = obj.Address;

            _context.Cellars.Update(cellar);
            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(string code)
        {
            var cellar = await _context.Cellars.SingleAsync(x => x.Code == code);
             
            _context.Cellars.Remove(cellar);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<Cellar> GetByCodeAsync(string code)
        {
            return await _context.Cellars.FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task<IQueryable<Cellar>> GetAllAsync()
        {
            return _context.Cellars;
        }
        #endregion

    }
}

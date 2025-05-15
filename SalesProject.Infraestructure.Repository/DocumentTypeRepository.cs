using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class DocumentTypeRepository : IGenericRepositoryThree<DocumentType>
    {
        private readonly ApiDbContext _context;
        public DocumentTypeRepository()
        {
            _context = new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(DocumentType obj)
        {
            await _context.DocumentTypes.AddAsync(obj);
            int insert = await _context.SaveChangesAsync();

            return insert > 0;
        }
        public async Task<bool> UpdateAsync(int id, DocumentType obj)
        {
            var documentType = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id);

            documentType.Description = obj.Description;

            int updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var documentType = await _context.DocumentTypes.SingleAsync(x => x.Id == id);

            _context.DocumentTypes.Remove(documentType);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<DocumentType> GetByIdAsync(int id)
        {
            return await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<DocumentType>> GetAllAsync()
        {
            return _context.DocumentTypes;

        }
        #endregion
    }
}

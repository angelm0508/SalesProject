using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class DocumentRepository : IGenericRepositoryThree<Document>
    {
        private readonly ApiDbContext _context;

        public DocumentRepository()
        {
            _context = new ApiDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(Document obj)
        {
            await _context.Documents.AddAsync(obj);
            int inserted = await _context.SaveChangesAsync();

            return inserted > 0;
        }
        public async Task<bool> UpdateAsync(int id, Document obj)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            document.Description = obj.Description;
            document.Serie = obj.Serie;

            int updated = await _context.SaveChangesAsync();

            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var document = await _context.Documents.SingleAsync(x => x.Id == id);
            
            _context.Documents.Remove(document);
            int deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<Document> GetByIdAsync(int id)
        {
            return await _context.Documents.Include(x => x.DocumentType).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IQueryable<Document>> GetAllAsync()
        {
            return _context.Documents.Include(x => x.DocumentType);
        }
        #endregion
    }
}

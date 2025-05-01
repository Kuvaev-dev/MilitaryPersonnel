using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DocumentStatusRepository : IDocumentStatusRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DocumentStatusRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDocumentStatusAsync(DocumentStatus documentStatus)
        {
            var entity = new DocumentStatuses
            {
                StatusName = documentStatus.StatusName,
            };

            _context.DocumentStatuses.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentStatusAsync(int id)
        {
            var documentStatus = await GetDocumentStatusByIdAsync(id);
            if (documentStatus == null) return false;

            var documentStatusEntity = new DocumentStatuses
            {
                Id = documentStatus.Id,
                StatusName = documentStatus.StatusName,
            };

            _context.DocumentStatuses.Remove(documentStatusEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DocumentStatus>> GetAllDocumentStatusesAsync()
        {
            var entities = await _context.DocumentStatuses
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new DocumentStatus
            {
                Id = a.Id,
                StatusName = a.StatusName,
            });
        }

        public async Task<DocumentStatus> GetDocumentStatusByIdAsync(int id)
        {
            var entity = await _context.DocumentStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new DocumentStatus
            {
                Id = entity.Id,
                StatusName = entity.StatusName,
            };
        }

        public async Task<bool> UpdateDocumentStatusAsync(DocumentStatus documentStatus)
        {
            var entity = await _context.DocumentStatuses.FindAsync(documentStatus.Id);
            if (entity == null) return false;

            entity.StatusName = documentStatus.StatusName;

            _context.DocumentStatuses.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

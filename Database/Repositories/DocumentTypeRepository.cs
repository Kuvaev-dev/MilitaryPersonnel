using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DocumentTypeRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDocumentTypeAsync(DocumentType documentStatus)
        {
            var entity = new DocumentTypes
            {
                TypeName = documentStatus.TypeName,
            };

            _context.DocumentTypes.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentTypeAsync(int id)
        {
            var documentStatus = await GetDocumentTypeByIdAsync(id);
            if (documentStatus == null) return false;

            var documentStatusEntity = new DocumentTypes
            {
                Id = documentStatus.Id,
                TypeName = documentStatus.TypeName,
            };

            _context.DocumentTypes.Remove(documentStatusEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DocumentType>> GetAllDocumentTypesAsync()
        {
            var entities = await _context.DocumentTypes
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new DocumentType
            {
                Id = a.Id,
                TypeName = a.TypeName,
            });
        }

        public async Task<DocumentType> GetDocumentTypeByIdAsync(int id)
        {
            var entity = await _context.DocumentTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new DocumentType
            {
                Id = entity.Id,
                TypeName = entity.TypeName,
            };
        }

        public async Task<bool> UpdateDocumentTypeAsync(DocumentType documentStatus)
        {
            var entity = await _context.DocumentTypes.FindAsync(documentStatus.Id);
            if (entity == null) return false;

            entity.TypeName = documentStatus.TypeName;

            _context.DocumentTypes.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

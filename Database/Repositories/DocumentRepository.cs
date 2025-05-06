using Database.Context;
using Database.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DocumentRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Document>> GetAllDocumentsAsync()
        {
            var entities = await _context.Documents
                .AsNoTracking()
                .Include(d => d.Serviceman)
                .ToListAsync();

            return entities.Select(d => new Domain.Models.Document
            {
                Id = d.Id,
                ServicemanId = d.ServicemanId ?? 0,
                ServicemenFullName = d.Serviceman != null
                    ? $"{d.Serviceman.LastName} {d.Serviceman.FirstName} {d.Serviceman.MiddleName}".Trim()
                    : null,
                DocumentType = d.DocumentType,
                DocumentNumber = d.DocumentNumber,
                IssueDate = d.IssueDate
            }).ToList();
        }

        public async Task<Domain.Models.Document?> GetDocumentByIdAsync(int id)
        {
            var entity = await _context.Documents
                .AsNoTracking()
                .Include(d => d.Serviceman)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (entity == null) return null;

            return new Domain.Models.Document
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId ?? 0,
                ServicemenFullName = entity.Serviceman != null
                    ? $"{entity.Serviceman.LastName} {entity.Serviceman.FirstName} {entity.Serviceman.MiddleName}".Trim()
                    : null,
                DocumentType = entity.DocumentType,
                DocumentNumber = entity.DocumentNumber,
                IssueDate = entity.IssueDate
            };
        }

        public async Task<bool> AddDocumentAsync(Domain.Models.Document document)
        {
            var entity = new Documents
            {
                ServicemanId = document.ServicemanId,
                DocumentType = document.DocumentType,
                DocumentNumber = document.DocumentNumber,
                IssueDate = document.IssueDate
            };

            _context.Documents.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentAsync(Domain.Models.Document document)
        {
            var entity = await _context.Documents.FindAsync(document.Id);
            if (entity == null) return false;

            entity.ServicemanId = document.ServicemanId;
            entity.DocumentType = document.DocumentType;
            entity.DocumentNumber = document.DocumentNumber;
            entity.IssueDate = document.IssueDate;

            _context.Documents.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var entity = await _context.Documents.FindAsync(id);
            if (entity == null) return false;

            _context.Documents.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
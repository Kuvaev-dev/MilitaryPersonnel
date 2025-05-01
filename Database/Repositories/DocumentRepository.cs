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
                ServicemanId = d.ServicemanId,
                ServicemenFullName = d.Serviceman?.LastName + " " + d.Serviceman?.FirstName + " " + d.Serviceman?.MiddleName,
                DocumentType = d.DocumentType,
                DocumentNumber = d.DocumentNumber,
                IssueDate = d.IssueDate,
            });
        }

        public async Task<Domain.Models.Document> GetDocumentByIdAsync(int id)
        {
            var entity = await _context.Documents
                .AsNoTracking()
                .Include(d => d.Serviceman)
                .FirstOrDefaultAsync(d => d.Id == id);

            return entity == null ? null : new Domain.Models.Document
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                DocumentType = entity.DocumentType,
                DocumentNumber = entity.DocumentNumber,
                IssueDate = entity.IssueDate,
            };
        }

        public async Task<bool> AddDocumentAsync(Domain.Models.Document document)
        {
            var entity = new Documents
            {
                ServicemanId = document.ServicemanId,
                DocumentType = document.DocumentType,
                DocumentNumber = document.DocumentNumber,
                IssueDate = document.IssueDate,
            };

            _context.Documents.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentAsync(Domain.Models.Document document)
        {
            var entity = await GetDocumentByIdAsync(document.Id);
            if (entity == null) return false;

            entity.ServicemanId = document.ServicemanId;
            entity.DocumentType = document.DocumentType;
            entity.DocumentNumber = document.DocumentNumber;
            entity.IssueDate = document.IssueDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var document = await GetDocumentByIdAsync(id);
            if (document == null) return false;

            var documentEntity = new Documents
            {
                Id = document.Id,
                ServicemanId = document.ServicemanId,
                DocumentType = document.DocumentType,
                DocumentNumber = document.DocumentNumber,
                IssueDate = document.IssueDate,
            };

            _context.Documents.Remove(documentEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

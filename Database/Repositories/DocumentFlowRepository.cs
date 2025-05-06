using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DocumentFlowRepository : IDocumentFlowRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DocumentFlowRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.DocumentFlow>> GetAllDocumentFLowsAsync()
        {
            var entities = await _context.DocumentFlow
                .AsNoTracking()
                .Include(s => s.DocumentType)
                .Include(s => s.CreatedBy)
                .Include(s => s.Status)
                .ToListAsync();

            return entities.Select(a => new Domain.Models.DocumentFlow
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                DocumentTypeId = a.DocumentTypeId,
                DocumentType = a.DocumentType?.TypeName,
                CreatedById = a.CreatedById,
                CreatedDate = a.CreatedDate,
                StatusId = a.StatusId,
                Status = a.Status?.StatusName,
                CreatedBy = a.CreatedBy != null
                    ? $"{a.CreatedBy.FirstName} {a.CreatedBy.LastName}"
                    : null,
            }).ToList();
        }

        public async Task<Domain.Models.DocumentFlow?> GetDocumentFLowByIdAsync(int id)
        {
            var entity = await _context.DocumentFlow
                .AsNoTracking()
                .Include(s => s.DocumentType)
                .Include(s => s.CreatedBy)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Domain.Models.DocumentFlow
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                DocumentTypeId = entity.DocumentTypeId,
                DocumentType = entity.DocumentType?.TypeName,
                CreatedById = entity.CreatedById,
                CreatedDate = entity.CreatedDate,
                StatusId = entity.StatusId,
                Status = entity.Status?.StatusName,
                CreatedBy = entity.CreatedBy != null
                    ? $"{entity.CreatedBy.FirstName} {entity.CreatedBy.LastName}"
                    : null,
            };
        }

        public async Task<Domain.Models.DocumentFlow> GetDocumentFLowByServicemanIdAsync(int id)
        {
            var documentFlow = await _context.DocumentFlow
                .AsNoTracking()
                .Include(df => df.DocumentType)
                .Include(df => df.CreatedBy)
                .Include(df => df.Status)
                .FirstOrDefaultAsync(df => df.CreatedById == id);

            return new Domain.Models.DocumentFlow
            {
                Id = documentFlow.Id,
                Title = documentFlow.Title,
                Content = documentFlow.Content,
                DocumentTypeId = documentFlow.DocumentTypeId,
                DocumentType = documentFlow.DocumentType?.TypeName,
                CreatedById = documentFlow.CreatedById,
                CreatedBy = documentFlow.CreatedBy != null
                    ? $"{documentFlow.CreatedBy.LastName} {documentFlow.CreatedBy.FirstName}".Trim()
                    : null,
                CreatedDate = documentFlow.CreatedDate,
                StatusId = documentFlow.StatusId,
                Status = documentFlow.Status?.StatusName
            };
        }

        public async Task<int> AddDocumentFLowAsync(Domain.Models.DocumentFlow document)
        {
            var entity = new Models.DocumentFlow
            {
                Title = document.Title,
                Content = document.Content,
                DocumentTypeId = document.DocumentTypeId,
                CreatedDate = document.CreatedDate,
                StatusId = document.StatusId
            };
            _context.DocumentFlow.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateDocumentFLowAsync(Domain.Models.DocumentFlow document)
        {
            var entity = await _context.DocumentFlow.FindAsync(document.Id);
            if (entity == null) return false;

            entity.Title = document.Title;
            entity.Content = document.Content;
            entity.DocumentTypeId = document.DocumentTypeId;
            entity.CreatedDate = document.CreatedDate;
            entity.StatusId = document.StatusId;

            _context.DocumentFlow.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentFLowAsync(int id)
        {
            var entity = await _context.DocumentFlow.FindAsync(id);
            if (entity == null) return false;

            _context.DocumentFlow.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignDocumentAsync(int documentId, int assigneeId)
        {
            var entity = new DocumentAssignments
            {
                DocumentId = documentId,
                AssigneeId = assigneeId,
                AssignedDate = DateTime.Now,
                IsCompleted = false
            };

            _context.DocumentAssignments.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ResolveDocumentAsync(int documentId, int authorId, string resolutionText)
        {
            var entity = new Resolutions
            {
                DocumentId = documentId,
                AuthorId = authorId,
                ResolutionText = resolutionText,
                ResolutionDate = DateTime.Now
            };

            _context.Resolutions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DocumentAssignment>> GetDocumentAssignmentsAsync(int documentId)
        {
            var entities = await _context.DocumentAssignments
                .AsNoTracking()
                .Where(da => da.DocumentId == documentId)
                .Include(da => da.Assignee)
                .ToListAsync();

            return entities.Select(da => new DocumentAssignment
            {
                Id = da.Id,
                DocumentId = da.DocumentId,
                AssigneeId = da.AssigneeId,
                ServicemenFullName = da.Assignee != null
                    ? $"{da.Assignee.LastName} {da.Assignee.FirstName}"
                    : null,
                AssignedDate = da.AssignedDate,
                IsCompleted = da.IsCompleted,
                CompletedDate = da.CompletedDate
            }).ToList();
        }

        public async Task<bool> ApproveDocumentAsync(int documentId, int statusId)
        {
            var entity = await _context.DocumentFlow.FindAsync(documentId);
            if (entity == null) return false;

            entity.StatusId = statusId;
            _context.DocumentFlow.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectDocumentAsync(int documentId, int statusId, string reason)
        {
            var entity = await _context.DocumentFlow.FindAsync(documentId);
            if (entity == null) return false;

            entity.StatusId = statusId;

            var resolution = new Resolutions
            {
                DocumentId = documentId,
                AuthorId = entity.CreatedById,
                ResolutionText = $"Document rejected: {reason}",
                ResolutionDate = DateTime.Now
            };
            _context.Resolutions.Add(resolution);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

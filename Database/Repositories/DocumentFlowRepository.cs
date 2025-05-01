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
                DocumentType = a.DocumentType.TypeName,
                CreatedById = a.CreatedById,
                CreatedDate = a.CreatedDate,
                StatusId = a.StatusId,
                Status = a.Status.StatusName,
                CreatedBy = a.CreatedBy.FirstName + " " + a.CreatedBy.LastName,
            });
        }

        public async Task<Domain.Models.DocumentFlow> GetDocumentFLowByIdAsync(int id)
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
                DocumentType = entity.DocumentType.TypeName,
                CreatedById = entity.CreatedById,
                CreatedDate = entity.CreatedDate,
                StatusId = entity.StatusId,
                Status = entity.Status.StatusName,
                CreatedBy = entity.CreatedBy.FirstName + " " + entity.CreatedBy.LastName,
            };
        }

        public async Task<bool> AddDocumentFLowAsync(Domain.Models.DocumentFlow document)
        {
            var entity = new Models.DocumentFlow
            {
                Title = document.Title,
                Content = document.Content,
                DocumentTypeId = document.DocumentTypeId,
                CreatedById = document.CreatedById,
                CreatedDate = document.CreatedDate,
                StatusId = document.StatusId,
            };
            _context.DocumentFlow.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentFLowAsync(Domain.Models.DocumentFlow document)
        {
            var entity = await _context.DocumentFlow.FindAsync(document.Id);
            if (entity != null)
            {
                entity.Title = document.Title;
                entity.Content = document.Content;
                entity.DocumentTypeId = document.DocumentTypeId;
                entity.CreatedById = document.CreatedById;
                entity.CreatedDate = document.CreatedDate;
                entity.StatusId = document.StatusId;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDocumentFLowAsync(int id)
        {
            var entity = await _context.DocumentFlow.FindAsync(id);
            if (entity != null)
            {
                _context.DocumentFlow.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
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
                .Include(da => da.Servicemen)
                .ToListAsync();

            return entities.Select(da => new DocumentAssignment
            {
                Id = da.Id,
                DocumentId = da.DocumentId,
                AssigneeId = da.AssigneeId,
                ServicemenFullName = da.Servicemen?.LastName + " " + da.Servicemen?.FirstName,
                AssignedDate = da.AssignedDate,
                IsCompleted = da.IsCompleted,
                CompletedDate = da.CompletedDate
            });
        }

        public async Task<bool> ApproveDocumentAsync(int documentId, int statusId)
        {
            var entity = await _context.DocumentFlow.FindAsync(documentId);
            if (entity == null) return false;

            entity.StatusId = statusId;
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

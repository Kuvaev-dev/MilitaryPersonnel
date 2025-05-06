using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DocumentAssignmentRepository : IDocumentAssignmentRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DocumentAssignmentRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDocumentAssignmentAsync(DocumentAssignment documentAssignment)
        {
            var entity = new DocumentAssignments
            {
                DocumentId = documentAssignment.DocumentId,
                AssigneeId = documentAssignment.AssigneeId,
                AssignedDate = documentAssignment.AssignedDate,
                IsCompleted = documentAssignment.IsCompleted,
                CompletedDate = documentAssignment.CompletedDate,
            };

            _context.DocumentAssignments.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentAssignmentAsync(int id)
        {
            var documentAssignment = await GetDocumentAssignmentByIdAsync(id);
            if (documentAssignment == null) return false;

            var awardEntity = new DocumentAssignments
            {
                DocumentId = documentAssignment.DocumentId,
                AssigneeId = documentAssignment.AssigneeId,
                AssignedDate = documentAssignment.AssignedDate,
                IsCompleted = documentAssignment.IsCompleted,
                CompletedDate = documentAssignment.CompletedDate,
            };

            _context.DocumentAssignments.Remove(awardEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DocumentAssignment>> GetAllDocumentAssignmentsAsync()
        {
            var entities = await _context.DocumentAssignments
                .AsNoTracking()
                .Include(s => s.Assignee)
                .Include(d => d.Document)
                .ToListAsync();

            return entities.Select(a => new DocumentAssignment
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
                DocumentTitle = a.Document.Title,
                AssigneeId = a.AssigneeId,
                AssignedDate = a.AssignedDate,
                IsCompleted = a.IsCompleted,
                CompletedDate = a.CompletedDate,
                ServicemenFullName = a.Assignee.LastName + " " + a.Assignee.FirstName + " " + a.Assignee.MiddleName,
            });
        }

        public async Task<DocumentAssignment> GetDocumentAssignmentByIdAsync(int id)
        {
            var entity = await _context.DocumentAssignments
                .Include(s => s.Assignee)
                .Include(d => d.Document)
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new DocumentAssignment
            {
                Id = entity.Id,
                DocumentId = entity.DocumentId,
                DocumentTitle = entity.Document.Title,
                AssigneeId = entity.AssigneeId,
                AssignedDate = entity.AssignedDate,
                IsCompleted = entity.IsCompleted,
                CompletedDate = entity.CompletedDate,
                ServicemenFullName = entity.Assignee.LastName + " " + entity.Assignee.FirstName + " " + entity.Assignee.MiddleName,
            };
        }

        public async Task<IEnumerable<DocumentAssignment>> GetDocumentAssignmentsByAssigneeIdAsync(int assigneeId)
        {
            var entities = await _context.DocumentAssignments
                .AsNoTracking()
                .Include(s => s.Assignee)
                .Include(d => d.Document)
                .Where(a => a.AssigneeId == assigneeId)
                .ToListAsync();

            return entities.Select(a => new DocumentAssignment
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
                DocumentTitle = a.Document.Title,
                AssigneeId = a.AssigneeId,
                AssignedDate = a.AssignedDate,
                IsCompleted = a.IsCompleted,
                CompletedDate = a.CompletedDate,
                ServicemenFullName = a.Assignee.LastName + " " + a.Assignee.FirstName + " " + a.Assignee.MiddleName,
            });
        }

        public async Task<IEnumerable<DocumentAssignment>> GetDocumentAssignmentsByDocumentIdAsync(int documentId)
        {
            var entities = await _context.DocumentAssignments
                .AsNoTracking()
                .Include(s => s.Assignee)
                .Include(d => d.Document)
                .Where(a => a.DocumentId == documentId)
                .ToListAsync();

            return entities.Select(a => new DocumentAssignment
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
                DocumentTitle = a.Document.Title,
                AssigneeId = a.AssigneeId,
                AssignedDate = a.AssignedDate,
                IsCompleted = a.IsCompleted,
                CompletedDate = a.CompletedDate,
                ServicemenFullName = a.Assignee.LastName + " " + a.Assignee.FirstName + " " + a.Assignee.MiddleName,
            });
        }

        public async Task<bool> UpdateDocumentAssignmentAsync(DocumentAssignment documentAssignment)
        {
            var entity = await _context.DocumentAssignments.FindAsync(documentAssignment.Id);
            if (entity == null) return false;

            entity.DocumentId = documentAssignment.DocumentId;
            entity.AssigneeId = documentAssignment.AssigneeId;
            entity.AssignedDate = documentAssignment.AssignedDate;
            entity.IsCompleted = documentAssignment.IsCompleted;
            entity.CompletedDate = documentAssignment.CompletedDate;

            _context.DocumentAssignments.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

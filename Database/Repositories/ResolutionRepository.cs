using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ResolutionRepository : IResolutionRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ResolutionRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddResolutionAsync(Resolution resolution)
        {
            var entity = new Resolutions
            {
                DocumentId = resolution.DocumentId,
                AuthorId = resolution.AuthorId,
                ResolutionText = resolution.ResolutionText,
                ResolutionDate = resolution.ResolutionDate,
            };

            _context.Resolutions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteResolutionAsync(int id)
        {
            var resolution = await GetResolutionByIdAsync(id);
            if (resolution == null) return false;

            var resolutionEntity = new Resolutions
            {
                Id = resolution.Id,
                DocumentId = resolution.DocumentId,
                AuthorId = resolution.AuthorId,
                ResolutionText = resolution.ResolutionText,
                ResolutionDate = resolution.ResolutionDate,
            };

            _context.Resolutions.Remove(resolutionEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Resolution>> GetAllResolutionsAsync()
        {
            var entities = await _context.Resolutions
                .AsNoTracking()
                .Include(a => a.Document)
                .Include(a => a.Author)
                .ToListAsync();

            return entities.Select(a => new Resolution
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
                DocumentTitle = a.Document?.Title,
                AuthorId = a.AuthorId,
                AuthorFullName = a.Author?.LastName + " " + a.Author?.FirstName + " " + a.Author?.MiddleName,
                ResolutionText = a.ResolutionText,
                ResolutionDate = a.ResolutionDate,
            });
        }

        public async Task<Resolution> GetResolutionByIdAsync(int id)
        {
            var entity = await _context.Resolutions
                .AsNoTracking()
                .Include(a => a.Document)
                .Include(a => a.Author)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Resolution
            {
                Id = entity.Id,
                DocumentId = entity.DocumentId,
                DocumentTitle = entity.Document?.Title,
                AuthorId = entity.AuthorId,
                AuthorFullName = entity.Author?.LastName + " " + entity.Author?.FirstName + " " + entity.Author?.MiddleName,
                ResolutionText = entity.ResolutionText,
                ResolutionDate = entity.ResolutionDate,
            };
        }

        public async Task<IEnumerable<Resolution>> GetResolutionsByAuthorIdAsync(int authorId)
        {
            var entities = await _context.Resolutions
                .AsNoTracking()
                .Include(a => a.Document)
                .Include(a => a.Author)
                .Where(a => a.AuthorId == authorId)
                .ToListAsync();

            return entities.Select(a => new Resolution
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
                DocumentTitle = a.Document?.Title,
                AuthorId = a.AuthorId,
                AuthorFullName = a.Author?.LastName + " " + a.Author?.FirstName + " " + a.Author?.MiddleName,
                ResolutionText = a.ResolutionText,
                ResolutionDate = a.ResolutionDate,
            });
        }

        public async Task<IEnumerable<Resolution>> GetResolutionsByDocumentIdAsync(int documentId)
        {
            var entities = await _context.Resolutions
                .AsNoTracking()
                .Include(a => a.Document)
                .Include(a => a.Author)
                .Where(a => a.DocumentId == documentId)
                .ToListAsync();

            return entities.Select(a => new Resolution
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
                DocumentTitle = a.Document?.Title,
                AuthorId = a.AuthorId,
                AuthorFullName = a.Author?.LastName + " " + a.Author?.FirstName + " " + a.Author?.MiddleName,
                ResolutionText = a.ResolutionText,
                ResolutionDate = a.ResolutionDate,
            });
        }

        public async Task<bool> UpdateResolutionAsync(Resolution resolution)
        {
            var entity = await _context.Resolutions.FindAsync(resolution.Id);
            if (entity == null) return false;

            entity.DocumentId = resolution.DocumentId;
            entity.AuthorId = resolution.AuthorId;
            entity.ResolutionText = resolution.ResolutionText;
            entity.ResolutionDate = resolution.ResolutionDate;

            _context.Resolutions.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

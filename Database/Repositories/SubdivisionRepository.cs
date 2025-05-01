using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class SubdivisionRepository : ISubdivisionRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public SubdivisionRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSubdivisionAsync(Subdivision subdivision)
        {
            var entity = new Subdivisions
            {
                SubdivisionName = subdivision.SubdivisionName,
                MilitaryUnitId = subdivision.MilitaryUnitId,
            };

            _context.Subdivisions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSubdivisionAsync(int id)
        {
            var subdivision = await GetSubdivisionByIdAsync(id);
            if (subdivision == null) return false;

            var subdivisionEntity = new Subdivisions
            {
                Id = subdivision.Id,
                SubdivisionName = subdivision.SubdivisionName,
                MilitaryUnitId = subdivision.MilitaryUnitId,
            };

            _context.Subdivisions.Remove(subdivisionEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Subdivision>> GetAllSubdivisionsAsync()
        {
            var entities = await _context.Subdivisions
                .AsNoTracking()
                .Include(m => m.MilitaryUnit)
                .ToListAsync();

            return entities.Select(a => new Subdivision
            {
                Id = a.Id,
                SubdivisionName = a.SubdivisionName,
                MilitaryUnitId = a.MilitaryUnitId.Value,
                MilitaryUnit = a.MilitaryUnit?.UnitName,
            });
        }

        public async Task<Subdivision> GetSubdivisionByIdAsync(int id)
        {
            var entity = await _context.Subdivisions
                .AsNoTracking()
                .Include(m => m.MilitaryUnit)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Subdivision
            {
                Id = entity.Id,
                SubdivisionName = entity.SubdivisionName,
                MilitaryUnitId = entity.MilitaryUnitId.Value,
                MilitaryUnit = entity.MilitaryUnit?.UnitName,
            };
        }

        public async Task<bool> UpdateSubdivisionAsync(Subdivision subdivision)
        {
            var entity = await _context.Subdivisions.FindAsync(subdivision.Id);
            if (entity == null) return false;

            entity.SubdivisionName = subdivision.SubdivisionName;
            entity.MilitaryUnitId = subdivision.MilitaryUnitId;

            _context.Subdivisions.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

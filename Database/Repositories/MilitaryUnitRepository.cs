using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MilitaryUnitRepository : IMilitaryUnitRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public MilitaryUnitRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMilitaryUnitAsync(MilitaryUnit militaryUnit)
        {
            var entity = new MilitaryUnits
            {
                UnitName = militaryUnit.UnitName,
            };

            _context.MilitaryUnits.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMilitaryUnitAsync(int id)
        {
            var militaryUnit = await GetMilitaryUnitByIdAsync(id);
            if (militaryUnit == null) return false;

            var militaryUnitEntity = new MilitaryUnits
            {
                Id = militaryUnit.Id,
                UnitName = militaryUnit.UnitName,
            };

            _context.MilitaryUnits.Remove(militaryUnitEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MilitaryUnit>> GetAllMilitaryUnitsAsync()
        {
            var entities = await _context.MilitaryUnits
                .AsNoTracking()
                .Include(s => s.Subdivisions)
                .ToListAsync();

            return entities.Select(a => new MilitaryUnit
            {
                Id = a.Id,
                UnitName = a.UnitName,
                Subdivisions = a.Subdivisions.Select(s => new Subdivision
                {
                    Id = s.Id,
                    SubdivisionName = s.SubdivisionName,
                }).ToList(),
            });
        }

        public async Task<MilitaryUnit?> GetMilitaryUnitByIdAsync(int id)
        {
            var entity = await _context.MilitaryUnits
                .AsNoTracking()
                .Include(s => s.Subdivisions)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new MilitaryUnit
            {
                Id = entity.Id,
                UnitName = entity.UnitName,
                Subdivisions = entity.Subdivisions.Select(s => new Subdivision
                {
                    Id = s.Id,
                    SubdivisionName = s.SubdivisionName,
                }).ToList(),
            };
        }

        public async Task<bool> UpdateMilitaryUnitAsync(MilitaryUnit militaryUnit)
        {
            var entity = await _context.MilitaryUnits.FindAsync(militaryUnit.Id);
            if (entity == null) return false;

            entity.UnitName = militaryUnit.UnitName;

            _context.MilitaryUnits.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

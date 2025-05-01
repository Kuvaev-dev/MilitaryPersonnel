using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MilitarySpecialtyRepository : IMilitarySpecialtyRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public MilitarySpecialtyRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(MilitarySpecialty militarySpecialty)
        {
            var entity = new MilitarySpecialties
            {
                SpecialtyName = militarySpecialty.SpecialtyName,
                Code = militarySpecialty.Code,
            };

            _context.MilitarySpecialties.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var militarySpecialty = await GetByIdAsync(id);
            if (militarySpecialty == null) return false;

            var militarySpecialtyEntity = new MilitarySpecialties
            {
                Id = militarySpecialty.Id,
                SpecialtyName = militarySpecialty.SpecialtyName,
                Code = militarySpecialty.Code,
            };

            _context.MilitarySpecialties.Remove(militarySpecialtyEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MilitarySpecialty>> GetAllAsync()
        {
            var entities = await _context.MilitarySpecialties
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new MilitarySpecialty
            {
                Id = a.Id,
                SpecialtyName = a.SpecialtyName,
                Code = a.Code,
            });
        }

        public async Task<MilitarySpecialty?> GetByIdAsync(int id)
        {
            var entity = await _context.MilitarySpecialties
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new MilitarySpecialty
            {
                Id = entity.Id,
                SpecialtyName = entity.SpecialtyName,
                Code = entity.Code,
            };
        }

        public async Task<bool> UpdateAsync(MilitarySpecialty militarySpecialty)
        {
            var entity = await _context.MilitarySpecialties.FindAsync(militarySpecialty.Id);
            if (entity == null) return false;

            entity.SpecialtyName = militarySpecialty.SpecialtyName;
            entity.Code = militarySpecialty.Code;

            _context.MilitarySpecialties.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

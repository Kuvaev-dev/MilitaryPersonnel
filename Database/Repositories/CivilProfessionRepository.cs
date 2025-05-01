using Database.Context;
using Database.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CivilProfessionRepository : ICivilProfessionRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public CivilProfessionRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.CivilProfession>> GetAllAsync()
        {
            var entities = await _context.CivilProfessions
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(cp => new Domain.Models.CivilProfession
            {
                Id = cp.Id,
                ProfessionName = cp.ProfessionName,
            });
        }

        public async Task<Domain.Models.CivilProfession> GetByIdAsync(int id)
        {
            var entity = await _context.CivilProfessions
                .AsNoTracking()
                .FirstOrDefaultAsync(cp => cp.Id == id);

            return entity == null ? null : new Domain.Models.CivilProfession
            {
                Id = entity.Id,
                ProfessionName = entity.ProfessionName,
            };
        }

        public async Task<bool> AddAsync(Domain.Models.CivilProfession civilProfession)
        {
            var entity = new CivilProfessions
            {
                ProfessionName = civilProfession.ProfessionName,
            };

            _context.CivilProfessions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Domain.Models.CivilProfession civilProfession)
        {
            var entity = await _context.CivilProfessions.FindAsync(civilProfession.Id);
            if (entity != null)
            {
                entity.ProfessionName = civilProfession.ProfessionName;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CivilProfessions.FindAsync(id);
            if (entity != null)
            {
                _context.CivilProfessions.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

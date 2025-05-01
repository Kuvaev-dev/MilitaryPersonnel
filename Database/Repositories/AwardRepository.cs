using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public AwardRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Award>> GetAllAwardsAsync()
        {
            var entities = await _context.Awards
                .AsNoTracking()
                .Include(s => s.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Award
            {
                Id = a.Id,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                AwardName = a.AwardName,
                AwardDate = a.AwardDate,
            });
        }

        public async Task<Award> GetAwardByIdAsync(int id)
        {
            var entity = await _context.Awards
                .AsNoTracking()
                .Include(s => s.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Award
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                AwardName = entity.AwardName,
                AwardDate = entity.AwardDate,
            };
        }

        public async Task<bool> AddAwardAsync(Award award)
        {
            var entity = new Awards
            {
                ServicemanId = award.ServicemanId,
                AwardName = award.AwardName,
                AwardDate = award.AwardDate,
            };

            _context.Awards.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAwardAsync(Award award)
        {
            var entity = await _context.Awards.FindAsync(award.Id);
            if (entity == null) return false;

            entity.ServicemanId = award.ServicemanId;
            entity.AwardName = award.AwardName;
            entity.AwardDate = award.AwardDate;

            _context.Awards.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAwardAsync(int id)
        {
            var award = await GetAwardByIdAsync(id);
            if (award == null) return false;

            var awardEntity = new Awards
            {
                Id = award.Id,
                ServicemanId = award.ServicemanId,
                AwardName = award.AwardName,
                AwardDate = award.AwardDate,
            };

            _context.Awards.Remove(awardEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

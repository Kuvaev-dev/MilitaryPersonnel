using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MobilizationListEntryRepository : IMobilizationListEntryRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public MobilizationListEntryRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMobilizationListEntryAsync(MobilizationListEntry entry)
        {
            var entity = new MobilizationListEntries
            {
                MobilizationListId = entry.MobilizationListId,
                ServicemanId = entry.ServicemanId,
            };

            _context.MobilizationListEntries.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMobilizationListEntryAsync(int id)
        {
            var mobList = await GetMobilizationListEntryAsync(id);
            if (mobList == null) return false;

            var mobListEntity = new MobilizationListEntries
            {
                Id = mobList.Id,
                MobilizationListId = mobList.MobilizationListId,
                ServicemanId = mobList.ServicemanId,
            };

            _context.MobilizationListEntries.Remove(mobListEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MobilizationListEntry>> GetMobilizationListEntriesAsync(int mobilizationListId)
        {
            var entities = await _context.MobilizationListEntries
                .AsNoTracking()
                .Include(a => a.MobilizationList)
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new MobilizationListEntry
            {
                Id = a.Id,
                MobilizationListId = a.MobilizationListId,
                MobilizationListName = a.MobilizationList?.ListName,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<MobilizationListEntry> GetMobilizationListEntryAsync(int id)
        {
            var entity = await _context.MobilizationListEntries
                .AsNoTracking()
                .Include(a => a.MobilizationList)
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new MobilizationListEntry
            {
                Id = entity.Id,
                MobilizationListId = entity.MobilizationListId,
                MobilizationListName = entity.MobilizationList?.ListName,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
            };
        }

        public async Task<bool> UpdateMobilizationListEntryAsync(MobilizationListEntry entry)
        {
            var entity = await _context.MobilizationListEntries.FindAsync(entry.Id);
            if (entity == null) return false;

            entity.MobilizationListId = entry.MobilizationListId;
            entity.ServicemanId = entry.ServicemanId;

            _context.MobilizationListEntries.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

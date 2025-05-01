using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MobilizationListRepository : IMobilizationListRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public MobilizationListRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMobilizationListAsync(MobilizationList mobilizationList)
        {
            var entity = new MobilizationLists
            {
                ListName = mobilizationList.ListName,
                CreationDate = mobilizationList.CreationDate,
            };

            _context.MobilizationLists.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMobilizationListAsync(int id)
        {
            var mobilizationList = await GetMobilizationListByIdAsync(id);
            if (mobilizationList == null) return false;

            var mobilizationListEntity = new MobilizationLists
            {
                Id = mobilizationList.Id,
                ListName = mobilizationList.ListName,
                CreationDate = mobilizationList.CreationDate,
            };

            _context.MobilizationLists.Remove(mobilizationListEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MobilizationList> GetMobilizationListByIdAsync(int id)
        {
            var entity = await _context.MobilizationLists
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new MobilizationList
            {
                Id = entity.Id,
                ListName = entity.ListName,
                CreationDate = entity.CreationDate,
            };
        }

        public async Task<IEnumerable<MobilizationList>> GetMobilizationListsAsync()
        {
            var entities = await _context.MobilizationLists
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new MobilizationList
            {
                Id = a.Id,
                ListName = a.ListName,
                CreationDate = a.CreationDate,
            });
        }

        public async Task<bool> UpdateMobilizationListAsync(MobilizationList mobilizationList)
        {
            var entity = await _context.MobilizationLists.FindAsync(mobilizationList.Id);
            if (entity == null) return false;

            entity.ListName = mobilizationList.ListName;
            entity.CreationDate = mobilizationList.CreationDate;

            _context.MobilizationLists.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

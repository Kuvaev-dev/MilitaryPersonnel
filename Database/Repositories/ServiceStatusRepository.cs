using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ServiceStatusRepository : IServiceStatusRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ServiceStatusRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddServiceStatusAsync(ServiceStatus serviceStatus)
        {
            var entity = new ServiceStatuses
            {
                StatusName = serviceStatus.StatusName,
            };

            _context.ServiceStatuses.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceStatusAsync(int id)
        {
            var serviceStatus = await GetServiceStatusByIdAsync(id);
            if (serviceStatus == null) return false;

            var serviceStatusEntity = new ServiceStatuses
            {
                Id = serviceStatus.Id,
                StatusName = serviceStatus.StatusName,
            };

            _context.ServiceStatuses.Remove(serviceStatusEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceStatus>> GetAllServiceStatusesAsync()
        {
            var entities = await _context.ServiceStatuses
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new ServiceStatus
            {
                Id = a.Id,
                StatusName = a.StatusName,
            });
        }

        public async Task<ServiceStatus> GetServiceStatusByIdAsync(int id)
        {
            var entity = await _context.ServiceStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new ServiceStatus
            {
                Id = entity.Id,
                StatusName = entity.StatusName,
            };
        }

        public async Task<bool> UpdateServiceStatusAsync(ServiceStatus serviceStatus)
        {
            var entity = await _context.ServiceStatuses.FindAsync(serviceStatus.Id);
            if (entity == null) return false;

            entity.StatusName = serviceStatus.StatusName;

            _context.ServiceStatuses.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

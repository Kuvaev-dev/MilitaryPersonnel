using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ServiceAttitudeRepository : IServiceAttitudeRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ServiceAttitudeRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddServiceAttitudeAsync(ServiceAttitude serviceAttitude)
        {
            var entity = new ServiceAttitudes
            {
                AttitudeDescription = serviceAttitude.AttitudeDescription,
            };

            _context.ServiceAttitudes.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceAttitudeAsync(int id)
        {
            var serviceAttitude = await GetServiceAttitudeByIdAsync(id);
            if (serviceAttitude == null) return false;

            var serviceAttitudeEntity = new ServiceAttitudes
            {
                Id = serviceAttitude.Id,
                AttitudeDescription = serviceAttitude.AttitudeDescription,
            };

            _context.ServiceAttitudes.Remove(serviceAttitudeEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceAttitude>> GetAllServiceAttitudesAsync()
        {
            var entities = await _context.ServiceAttitudes
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new ServiceAttitude
            {
                Id = a.Id,
                AttitudeDescription = a.AttitudeDescription,
            });
        }

        public async Task<ServiceAttitude> GetServiceAttitudeByIdAsync(int id)
        {
            var entity = await _context.ServiceAttitudes
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new ServiceAttitude
            {
                Id = entity.Id,
                AttitudeDescription = entity.AttitudeDescription,
            };
        }

        public async Task<bool> UpdateServiceAttitudeAsync(ServiceAttitude serviceAttitude)
        {
            var entity = await _context.ServiceAttitudes.FindAsync(serviceAttitude.Id);
            if (entity == null) return false;

            entity.AttitudeDescription = serviceAttitude.AttitudeDescription;

            _context.ServiceAttitudes.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

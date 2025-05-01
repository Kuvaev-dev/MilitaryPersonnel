using Database.Context;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ServiceHistoryRepository : IServiceHistoryRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ServiceHistoryRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddServiceHistory(Domain.Models.ServiceHistory serviceHistory)
        {
            var entity = new Models.ServiceHistory
            {
                ServicemanId = serviceHistory.ServicemanId,
                PositionId = serviceHistory.PositionId,
                SubdivisionId = serviceHistory.SubdivisionId,
                StartDate = serviceHistory.StartDate,
                EndDate = serviceHistory.EndDate,
            };

            _context.ServiceHistory.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceHistory(int id)
        {
            var serviceHistory = await GetServiceHistoryById(id);
            if (serviceHistory == null) return false;

            var serviceHistoryEntity = new Models.ServiceHistory
            {
                Id = serviceHistory.Id,
                PositionId = serviceHistory.PositionId,
                SubdivisionId = serviceHistory.SubdivisionId,
                StartDate = serviceHistory.StartDate,
                EndDate = serviceHistory.EndDate,
            };

            _context.ServiceHistory.Remove(serviceHistoryEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Domain.Models.ServiceHistory>> GetAllServiceHistories()
        {
            var entities = await _context.ServiceHistory
                .AsNoTracking()
                .Include(p => p.Position)
                .Include(p => p.Subdivision)
                .Include(p => p.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Domain.Models.ServiceHistory
            {
                Id = a.Id,
                PositionId = a.PositionId,
                PositionTitle = a.Position?.PositionName,
                SubdivisionId = a.SubdivisionId,
                SubdivisionTitle = a.Subdivision?.SubdivisionName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ServicemanId = a.ServicemanId,
                ServicemanFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<Domain.Models.ServiceHistory> GetServiceHistoryById(int id)
        {
            var entity = await _context.ServiceHistory
                .AsNoTracking()
                .Include(p => p.Position)
                .Include(p => p.Subdivision)
                .Include(p => p.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Domain.Models.ServiceHistory
            {
                Id = entity.Id,
                PositionId = entity.PositionId,
                PositionTitle = entity.Position?.PositionName,
                SubdivisionId = entity.SubdivisionId,
                SubdivisionTitle = entity.Subdivision?.SubdivisionName,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ServicemanId = entity.ServicemanId,
                ServicemanFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
            };
        }

        public async Task<IEnumerable<Domain.Models.ServiceHistory>> GetServiceHistoryByPositionId(int positionId)
        {
            var entities = await _context.ServiceHistory
                .AsNoTracking()
                .Include(p => p.Position)
                .Include(p => p.Subdivision)
                .Include(p => p.Serviceman)
                .Where(p => p.PositionId == positionId)
                .ToListAsync();

            return entities.Select(a => new Domain.Models.ServiceHistory
            {
                Id = a.Id,
                PositionId = a.PositionId,
                PositionTitle = a.Position?.PositionName,
                SubdivisionId = a.SubdivisionId,
                SubdivisionTitle = a.Subdivision?.SubdivisionName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ServicemanId = a.ServicemanId,
                ServicemanFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<IEnumerable<Domain.Models.ServiceHistory>> GetServiceHistoryByServicemanId(int servicemanId)
        {
            var entities = await _context.ServiceHistory
                .AsNoTracking()
                .Include(p => p.Position)
                .Include(p => p.Subdivision)
                .Include(p => p.Serviceman)
                .Where(p => p.ServicemanId == servicemanId)
                .ToListAsync();

            return entities.Select(a => new Domain.Models.ServiceHistory
            {
                Id = a.Id,
                PositionId = a.PositionId,
                PositionTitle = a.Position?.PositionName,
                SubdivisionId = a.SubdivisionId,
                SubdivisionTitle = a.Subdivision?.SubdivisionName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ServicemanId = a.ServicemanId,
                ServicemanFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<IEnumerable<Domain.Models.ServiceHistory>> GetServiceHistoryBySubdivisionId(int subdivisionId)
        {
            var entities = await _context.ServiceHistory
                .AsNoTracking()
                .Include(p => p.Position)
                .Include(p => p.Subdivision)
                .Include(p => p.Serviceman)
                .Where(p => p.SubdivisionId == subdivisionId)
                .ToListAsync();

            return entities.Select(a => new Domain.Models.ServiceHistory
            {
                Id = a.Id,
                PositionId = a.PositionId,
                PositionTitle = a.Position?.PositionName,
                SubdivisionId = a.SubdivisionId,
                SubdivisionTitle = a.Subdivision?.SubdivisionName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ServicemanId = a.ServicemanId,
                ServicemanFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<bool> UpdateServiceHistory(Domain.Models.ServiceHistory serviceHistory)
        {
            var entity = await _context.ServiceHistory.FindAsync(serviceHistory.Id);
            if (entity == null) return false;

            entity.PositionId = serviceHistory.PositionId;
            entity.SubdivisionId = serviceHistory.SubdivisionId;
            entity.StartDate = serviceHistory.StartDate;
            entity.EndDate = serviceHistory.EndDate;

            _context.ServiceHistory.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

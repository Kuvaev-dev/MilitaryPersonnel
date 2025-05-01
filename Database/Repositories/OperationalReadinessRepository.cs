using Database.Context;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class OperationalReadinessRepository : IOperationalReadinessRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public OperationalReadinessRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOperationalReadinessAsync(Domain.Models.OperationalReadiness operationalReadiness)
        {
            var entity = new Models.OperationalReadiness
            {
                ServicemanId = operationalReadiness.ServicemanId,
                ReadinessStatus = operationalReadiness.ReadinessStatus,
                AssessmentDate = operationalReadiness.AssessmentDate,
            };

            _context.OperationalReadiness.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOperationalReadinessAsync(int id)
        {
            var operationalReadiness = await GetOperationalReadinessByIdAsync(id);
            if (operationalReadiness == null) return false;

            var operationalReadinessEntity = new Models.OperationalReadiness
            {
                Id = operationalReadiness.Id,
                ServicemanId = operationalReadiness.ServicemanId,
                ReadinessStatus = operationalReadiness.ReadinessStatus,
                AssessmentDate = operationalReadiness.AssessmentDate,
            };

            _context.OperationalReadiness.Remove(operationalReadinessEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Domain.Models.OperationalReadiness>> GetAllOperationalReadinessAsync()
        {
            var entities = await _context.OperationalReadiness
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Domain.Models.OperationalReadiness
            {
                Id = a.Id,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                ReadinessStatus = a.ReadinessStatus,
                AssessmentDate = a.AssessmentDate,
            });
        }

        public async Task<Domain.Models.OperationalReadiness> GetOperationalReadinessAsync(int? servicemanId)
        {
            var entity = await _context.OperationalReadiness
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.ServicemanId == servicemanId);

            return entity == null ? null : new Domain.Models.OperationalReadiness
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                ReadinessStatus = entity.ReadinessStatus,
                AssessmentDate = entity.AssessmentDate,
            };
        }

        public async Task<Domain.Models.OperationalReadiness> GetOperationalReadinessByIdAsync(int id)
        {
            var entity = await _context.OperationalReadiness
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Domain.Models.OperationalReadiness
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ReadinessStatus = entity.ReadinessStatus,
                AssessmentDate = entity.AssessmentDate,
            };
        }

        public async Task<bool> UpdateOperationalReadinessAsync(Domain.Models.OperationalReadiness operationalReadiness)
        {
            var entity = await _context.OperationalReadiness.FindAsync(operationalReadiness.Id);
            if (entity == null) return false;

            entity.ServicemanId = operationalReadiness.ServicemanId;
            entity.ReadinessStatus = operationalReadiness.ReadinessStatus;
            entity.AssessmentDate = operationalReadiness.AssessmentDate;

            _context.OperationalReadiness.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

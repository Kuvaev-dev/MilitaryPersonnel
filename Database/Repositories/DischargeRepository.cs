using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DischargeRepository : IDischargeRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DischargeRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDischargeAsync(Discharge discharge)
        {
            var entity = new Discharges
            {
                ServicemanId = discharge.ServicemanId,
                DischargeDate = discharge.DischargeDate,
                DischargeReason = discharge.DischargeReason,
            };

            _context.Discharges.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDischargeAsync(int id)
        {
            var discharge = await GetDischargeByIdAsync(id);
            if (discharge == null) return false;

            var dischargeEntity = new Discharges
            {
                Id = discharge.Id,
                ServicemanId = discharge.ServicemanId,
                DischargeDate = discharge.DischargeDate,
                DischargeReason = discharge.DischargeReason,
            };

            _context.Discharges.Remove(dischargeEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Discharge>> GetAllDischargesAsync()
        {
            var entities = await _context.Discharges
                .AsNoTracking()
                .Include(s => s.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Discharge
            {
                Id = a.Id,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                DischargeDate = a.DischargeDate,
                DischargeReason = a.DischargeReason,
            });
        }

        public async Task<Discharge?> GetDischargeByIdAsync(int id)
        {
            var entity = await _context.Discharges
                .AsNoTracking()
                .Include(s => s.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Discharge
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                DischargeDate = entity.DischargeDate,
                DischargeReason = entity.DischargeReason,
            };
        }

        public async Task<bool> UpdateDischargeAsync(Discharge discharge)
        {
            var entity = await _context.Discharges.FindAsync(discharge.Id);
            if (entity == null) return false;

            entity.ServicemanId = discharge.ServicemanId;
            entity.ServicemanId = discharge.ServicemanId;
            entity.DischargeDate = discharge.DischargeDate;
            entity.DischargeReason = discharge.DischargeReason;

            _context.Discharges.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Database.Context;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DischargeLogRepository : IDischargeLogRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public DischargeLogRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.DischargeLog>> GetAllAsync()
        {
            var entities = await _context.DischargeLog.ToListAsync();
            return entities.Select(e => new Domain.Models.DischargeLog
            {
                Id = e.Id,
                ServicemanId = e.ServicemanId,
                DischargeDate = e.DischargeDate,
                DischargeReason = e.DischargeReason,
                LogDate = e.LogDate
            }).ToList();
        }

        public async Task<Domain.Models.DischargeLog?> GetByIdAsync(int id)
        {
            var entity = await _context.DischargeLog.FindAsync(id);
            if (entity == null) return null;
            return new Domain.Models.DischargeLog
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                DischargeDate = entity.DischargeDate,
                DischargeReason = entity.DischargeReason,
                LogDate = entity.LogDate
            };
        }

        public async Task<bool> AddAsync(Domain.Models.DischargeLog dischargeLog)
        {
            var entity = new Models.DischargeLog
            {
                ServicemanId = dischargeLog.ServicemanId,
                DischargeDate = dischargeLog.DischargeDate,
                DischargeReason = dischargeLog.DischargeReason,
                LogDate = dischargeLog.LogDate
            };
            await _context.DischargeLog.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Domain.Models.DischargeLog dischargeLog)
        {
            var entity = await _context.DischargeLog.FindAsync(dischargeLog.Id);
            if (entity == null) return false;

            entity.ServicemanId = dischargeLog.ServicemanId;
            entity.DischargeDate = dischargeLog.DischargeDate;
            entity.DischargeReason = dischargeLog.DischargeReason;
            entity.LogDate = dischargeLog.LogDate;

            _context.DischargeLog.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DischargeLog.FindAsync(id);
            if (entity == null) return false;
            _context.DischargeLog.Remove(entity);
            await _context.SaveChangesAsync();
            return true; 
        }
    }
}

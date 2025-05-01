using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class PunishmentRepository : IPunishmentRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public PunishmentRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPunishment(Punishment punishment)
        {
            var entity = new Punishments
            {
                PunishmentDescription = punishment.PunishmentDescription,
                PunishmentDate = punishment.PunishmentDate,
                ServicemanId = punishment.ServicemanId,
            };

            _context.Punishments.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePunishment(int punishmentId)
        {
            var punishment = await GetPunishmentById(punishmentId);
            if (punishment == null) return false;

            var punishmentEntity = new Punishments
            {
                Id = punishment.Id,
                PunishmentDescription = punishment.PunishmentDescription,
                PunishmentDate = punishment.PunishmentDate,
                ServicemanId = punishment.ServicemanId,
            };

            _context.Punishments.Remove(punishmentEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Punishment>> GetAllPunishments()
        {
            var entities = await _context.Punishments
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Punishment
            {
                Id = a.Id,
                PunishmentDescription = a.PunishmentDescription,
                PunishmentDate = a.PunishmentDate,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<Punishment> GetPunishmentById(int punishmentId)
        {
            var entity = await _context.Punishments
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == punishmentId);

            return entity == null ? null : new Punishment
            {
                Id = entity.Id,
                PunishmentDescription = entity.PunishmentDescription,
                PunishmentDate = entity.PunishmentDate,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
            };
        }

        public async Task<IEnumerable<Punishment>> GetPunishmentsByServicemanId(int servicemanId)
        {
            var entities = await _context.Punishments
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Punishment
            {
                Id = a.Id,
                PunishmentDescription = a.PunishmentDescription,
                PunishmentDate = a.PunishmentDate,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<bool> UpdatePunishment(Punishment punishment)
        {
            var entity = await _context.Punishments.FindAsync(punishment.Id);
            if (entity == null) return false;

            entity.PunishmentDescription = punishment.PunishmentDescription;
            entity.PunishmentDate = punishment.PunishmentDate;
            entity.ServicemanId = punishment.ServicemanId;

            _context.Punishments.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

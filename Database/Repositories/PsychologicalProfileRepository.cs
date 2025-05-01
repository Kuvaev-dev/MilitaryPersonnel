using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class PsychologicalProfileRepository : IPsychologicalProfileRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public PsychologicalProfileRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPsychologicalProfileAsync(PsychologicalProfile psychologicalProfile)
        {
            var entity = new PsychologicalProfiles
            {
                ServicemanId = psychologicalProfile.ServicemanId,
                ProfileDescription = psychologicalProfile.ProfileDescription,
                AssessmentDate = psychologicalProfile.AssessmentDate,
            };

            _context.PsychologicalProfiles.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePsychologicalProfileAsync(int id)
        {
            var psychologicalProfile = await GetPsychologicalProfileByIdAsync(id);
            if (psychologicalProfile == null) return false;

            var psychologicalProfileEntity = new PsychologicalProfiles
            {
                Id = psychologicalProfile.Id,
                ServicemanId = psychologicalProfile.ServicemanId,
                ProfileDescription = psychologicalProfile.ProfileDescription,
                AssessmentDate = psychologicalProfile.AssessmentDate,
            };

            _context.PsychologicalProfiles.Remove(psychologicalProfileEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PsychologicalProfile>> GetAllPsychologicalProfilesAsync()
        {
            var entities = await _context.PsychologicalProfiles
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new PsychologicalProfile
            {
                Id = a.Id,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                ProfileDescription = a.ProfileDescription,
                AssessmentDate = a.AssessmentDate,
            });
        }

        public async Task<PsychologicalProfile?> GetPsychologicalProfileByIdAsync(int id)
        {
            var entity = await _context.PsychologicalProfiles
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new PsychologicalProfile
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                ProfileDescription = entity.ProfileDescription,
                AssessmentDate = entity.AssessmentDate,
            };
        }

        public async Task<PsychologicalProfile?> GetPsychologicalProfileByServicemanIdAsync(int servicemanId)
        {
            var entity = await _context.PsychologicalProfiles
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.ServicemanId == servicemanId);

            return entity == null ? null : new PsychologicalProfile
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                ProfileDescription = entity.ProfileDescription,
                AssessmentDate = entity.AssessmentDate,
            };
        }

        public async Task<bool> UpdatePsychologicalProfileAsync(PsychologicalProfile psychologicalProfile)
        {
            var entity = await _context.PsychologicalProfiles.FindAsync(psychologicalProfile.Id);
            if (entity == null) return false;

            entity.ServicemanId = psychologicalProfile.ServicemanId;
            entity.ProfileDescription = psychologicalProfile.ProfileDescription;
            entity.AssessmentDate = psychologicalProfile.AssessmentDate;

            _context.PsychologicalProfiles.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

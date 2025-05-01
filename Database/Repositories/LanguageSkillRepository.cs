using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class LanguageSkillRepository : ILanguageSkillRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public LanguageSkillRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLanguageSkillAsync(LanguageSkill languageSkill)
        {
            var entity = new LanguageSkills
            {
                ServicemanId = languageSkill.ServicemanId,
                Language = languageSkill.Language,
                ProficiencyLevel = languageSkill.ProficiencyLevel,
            };

            _context.LanguageSkills.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLanguageSkillAsync(int id)
        {
            var languageSkill = await GetLanguageSkillByIdAsync(id);
            if (languageSkill == null) return false;

            var languageSkillEntity = new LanguageSkills
            {
                Id = languageSkill.Id,
                ServicemanId = languageSkill.ServicemanId,
                Language = languageSkill.Language,
                ProficiencyLevel = languageSkill.ProficiencyLevel,
            };

            _context.LanguageSkills.Remove(languageSkillEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LanguageSkill>> GetAllLanguageSkillsAsync()
        {
            var entities = await _context.LanguageSkills
                .AsNoTracking()
                .Include(a => a.Serviceman) 
                .ToListAsync();

            return entities.Select(a => new LanguageSkill
            {
                Id = a.Id,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                Language = a.Language,
                ProficiencyLevel = a.ProficiencyLevel,
            });
        }

        public async Task<LanguageSkill> GetLanguageSkillByIdAsync(int id)
        {
            var entity = await _context.LanguageSkills
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new LanguageSkill
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                Language = entity.Language,
                ProficiencyLevel = entity.ProficiencyLevel,
            };
        }

        public async Task<bool> UpdateLanguageSkillAsync(LanguageSkill languageSkill)
        {
            var entity = await _context.LanguageSkills.FindAsync(languageSkill.Id);
            if (entity == null) return false;

            entity.ServicemanId = languageSkill.ServicemanId;
            entity.Language = languageSkill.Language;
            entity.ProficiencyLevel = languageSkill.ProficiencyLevel;

            _context.LanguageSkills.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

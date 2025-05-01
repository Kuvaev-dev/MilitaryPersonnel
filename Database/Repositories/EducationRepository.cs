using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public EducationRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEducationAsync(Education education)
        {
            var entity = new Educations
            {
                EducationLevel = education.EducationLevel,
                Institution = education.Institution,
                Specialty = education.Specialty,
                GraduationYear = education.GraduationYear,
            };

            _context.Educations.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEducationAsync(int id)
        {
            var education = await GetEducationByIdAsync(id);
            if (education == null) return false;

            var educationEntity = new Educations
            {
                Id = education.Id,
                EducationLevel = education.EducationLevel,
                Institution = education.Institution,
                Specialty = education.Specialty,
                GraduationYear = education.GraduationYear
            };

            _context.Educations.Remove(educationEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Education>> GetAllEducationsAsync()
        {
            var entities = await _context.Educations
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new Education
            {
                Id = a.Id,
                EducationLevel = a.EducationLevel,
                Institution = a.Institution,
                Specialty = a.Specialty,
                GraduationYear = a.GraduationYear,
            });
        }

        public async Task<Education?> GetEducationByIdAsync(int id)
        {
            var entity = await _context.Educations
                 .AsNoTracking()
                 .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Education
            {
                Id = entity.Id,
                EducationLevel = entity.EducationLevel,
                Institution = entity.Institution,
                Specialty = entity.Specialty,
                GraduationYear = entity.GraduationYear,
            };
        }

        public async Task<bool> UpdateEducationAsync(Education education)
        {
            var entity = await _context.Educations.FindAsync(education.Id);
            if (entity == null) return false;

            entity.EducationLevel = education.EducationLevel;
            entity.Institution = education.Institution;
            entity.Specialty = education.Specialty;
            entity.GraduationYear = education.GraduationYear;

            _context.Educations.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class FitnessCategoryRepository : IFitnessCategoryRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public FitnessCategoryRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFitnessCategoryAsync(FitnessCategory fitnessCategory)
        {
            var entity = new FitnessCategories
            {
                CategoryName = fitnessCategory.CategoryName,
            };

            _context.FitnessCategories.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFitnessCategoryAsync(int id)
        {
            var fitnessCategory = await GetFitnessCategoryByIdAsync(id);
            if (fitnessCategory == null) return false;

            var fitnessCategoryEntity = new FitnessCategories
            {
                Id = fitnessCategory.Id,
                CategoryName = fitnessCategory.CategoryName,
            };

            _context.FitnessCategories.Remove(fitnessCategoryEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FitnessCategory>> GetAllFitnessCategoriesAsync()
        {
            var entities = await _context.FitnessCategories
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new FitnessCategory
            {
                Id = a.Id,
                CategoryName = a.CategoryName,
            });
        }

        public async Task<FitnessCategory> GetFitnessCategoryByIdAsync(int id)
        {
            var entity = await _context.FitnessCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new FitnessCategory
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };
        }

        public async Task<bool> UpdateFitnessCategoryAsync(FitnessCategory fitnessCategory)
        {
            var entity = await _context.FitnessCategories.FindAsync(fitnessCategory.Id);
            if (entity == null) return false;

            entity.CategoryName = fitnessCategory.CategoryName;

            _context.FitnessCategories.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

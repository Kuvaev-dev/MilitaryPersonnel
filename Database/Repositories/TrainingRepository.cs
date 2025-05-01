using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public TrainingRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTrainingAsync(Training training)
        {
            var entity = new Trainings
            {
                TrainingName = training.TrainingName,
                StartDate = training.StartDate,
                EndDate = training.EndDate,
            };

            _context.Trainings.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTrainingAsync(int id)
        {
            var training = await GetTrainingByIdAsync(id);
            if (training == null) return false;

            var trainingEntity = new Trainings
            {
                Id = training.Id,
                TrainingName = training.TrainingName,
                StartDate = training.StartDate,
                EndDate = training.EndDate,
            };

            _context.Trainings.Remove(trainingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Training>> GetAllTrainingsAsync()
        {
            var entities = await _context.Trainings
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new Training
            {
                Id = a.Id,
                TrainingName = a.TrainingName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
            });
        }

        public async Task<Training?> GetTrainingByIdAsync(int id)
        {
            var entity = await _context.Trainings
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Training
            {
                Id = entity.Id,
                TrainingName = entity.TrainingName,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
            };
        }

        public async Task<bool> UpdateTrainingAsync(Training training)
        {
            var entity = await _context.Trainings.FindAsync(training.Id);
            if (entity == null) return false;

            entity.TrainingName = training.TrainingName;
            entity.StartDate = training.StartDate;
            entity.EndDate = training.EndDate;

            _context.Trainings.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

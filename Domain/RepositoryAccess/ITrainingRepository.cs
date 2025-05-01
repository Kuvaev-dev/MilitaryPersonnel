using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface ITrainingRepository
    {
        Task<IEnumerable<Training>> GetAllTrainingsAsync();
        Task<Training?> GetTrainingByIdAsync(int id);
        Task<bool> AddTrainingAsync(Training training);
        Task<bool> UpdateTrainingAsync(Training training);
        Task<bool> DeleteTrainingAsync(int id);
    }
}

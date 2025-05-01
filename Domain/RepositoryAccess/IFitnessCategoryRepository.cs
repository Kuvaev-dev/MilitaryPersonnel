using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IFitnessCategoryRepository
    {
        Task<IEnumerable<FitnessCategory>> GetAllFitnessCategoriesAsync();
        Task<FitnessCategory> GetFitnessCategoryByIdAsync(int id);
        Task<bool> AddFitnessCategoryAsync(FitnessCategory fitnessCategory);
        Task<bool> UpdateFitnessCategoryAsync(FitnessCategory fitnessCategory);
        Task<bool> DeleteFitnessCategoryAsync(int id);
    }
}

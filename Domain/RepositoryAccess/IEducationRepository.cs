using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAllEducationsAsync();
        Task<Education?> GetEducationByIdAsync(int id);
        Task<bool> AddEducationAsync(Education education);
        Task<bool> UpdateEducationAsync(Education education);
        Task<bool> DeleteEducationAsync(int id);
    }
}

using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IResolutionRepository
    {
        Task<IEnumerable<Resolution>> GetAllResolutionsAsync();
        Task<Resolution> GetResolutionByIdAsync(int id);
        Task<IEnumerable<Resolution>> GetResolutionsByDocumentIdAsync(int documentId);
        Task<IEnumerable<Resolution>> GetResolutionsByAuthorIdAsync(int authorId);
        Task<bool> AddResolutionAsync(Resolution resolution);
        Task<bool> UpdateResolutionAsync(Resolution resolution);
        Task<bool> DeleteResolutionAsync(int id);
    }
}

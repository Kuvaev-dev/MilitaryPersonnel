using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface ISubdivisionRepository
    {
        Task<IEnumerable<Subdivision>> GetAllSubdivisionsAsync();
        Task<Subdivision> GetSubdivisionByIdAsync(int id);
        Task<bool> AddSubdivisionAsync(Subdivision subdivision);
        Task<bool> UpdateSubdivisionAsync(Subdivision subdivision);
        Task<bool> DeleteSubdivisionAsync(int id);
    }
}

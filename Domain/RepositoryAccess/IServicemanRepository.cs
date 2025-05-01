using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IServicemanRepository
    {
        Task<IEnumerable<Serviceman>> GetAllServicemenAsync();
        Task<Serviceman?> GetServicemanByIdAsync(int id);
        Task<bool> AddServicemanAsync(Serviceman serviceman);
        Task<bool> UpdateServicemanAsync(Serviceman serviceman);
        Task<bool> DeleteServicemanAsync(int id);
        Task<IEnumerable<Serviceman>> GetServicemenBySubdivisionIdAsync(int subdivisionId);
    }
}

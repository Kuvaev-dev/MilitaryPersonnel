using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IDischargeRepository
    {
        Task<IEnumerable<Discharge>> GetAllDischargesAsync();
        Task<Discharge?> GetDischargeByIdAsync(int id);
        Task<bool> AddDischargeAsync(Discharge discharge);
        Task<bool> UpdateDischargeAsync(Discharge discharge);
        Task<bool> DeleteDischargeAsync(int id);
    }
}

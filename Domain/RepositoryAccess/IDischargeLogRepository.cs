using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IDischargeLogRepository
    {
        Task<List<DischargeLog>> GetAllAsync();
        Task<DischargeLog?> GetByIdAsync(int id);
        Task<bool> AddAsync(DischargeLog dischargeLog);
        Task<bool> UpdateAsync(DischargeLog dischargeLog);
        Task<bool> DeleteAsync(int id);
    }
}

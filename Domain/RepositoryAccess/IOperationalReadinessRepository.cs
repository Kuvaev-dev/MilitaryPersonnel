using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IOperationalReadinessRepository
    {
        Task<OperationalReadiness> GetOperationalReadinessAsync(int? servicemanId);
        Task<IEnumerable<OperationalReadiness>> GetAllOperationalReadinessAsync();
        Task<OperationalReadiness> GetOperationalReadinessByIdAsync(int id);
        Task<bool> AddOperationalReadinessAsync(OperationalReadiness operationalReadiness);
        Task<bool> UpdateOperationalReadinessAsync(OperationalReadiness operationalReadiness);
        Task<bool> DeleteOperationalReadinessAsync(int id);
    }
}

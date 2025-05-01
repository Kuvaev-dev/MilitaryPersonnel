namespace Domain.RepositoryAccess
{
    public interface IServiceStatusRepository
    {
        Task<IEnumerable<Domain.Models.ServiceStatus>> GetAllServiceStatusesAsync();
        Task<Domain.Models.ServiceStatus> GetServiceStatusByIdAsync(int id);
        Task<bool> AddServiceStatusAsync(Domain.Models.ServiceStatus serviceStatus);
        Task<bool> UpdateServiceStatusAsync(Domain.Models.ServiceStatus serviceStatus);
        Task<bool> DeleteServiceStatusAsync(int id);
    }
}

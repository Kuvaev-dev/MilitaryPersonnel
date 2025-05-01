namespace Domain.RepositoryAccess
{
    public interface IServiceHistoryRepository
    {
        Task<IEnumerable<Domain.Models.ServiceHistory>> GetServiceHistoryByServicemanId(int servicemanId);
        Task<IEnumerable<Domain.Models.ServiceHistory>> GetServiceHistoryBySubdivisionId(int subdivisionId);
        Task<IEnumerable<Domain.Models.ServiceHistory>> GetServiceHistoryByPositionId(int positionId);
        Task<IEnumerable<Domain.Models.ServiceHistory>> GetAllServiceHistories();
        Task<Domain.Models.ServiceHistory> GetServiceHistoryById(int id);
        Task<bool> AddServiceHistory(Domain.Models.ServiceHistory serviceHistory);
        Task<bool> UpdateServiceHistory(Domain.Models.ServiceHistory serviceHistory);
        Task<bool> DeleteServiceHistory(int id);
    }
}

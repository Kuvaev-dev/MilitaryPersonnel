namespace Domain.RepositoryAccess
{
    public interface IMobilizationListRepository
    {
        Task<IEnumerable<Domain.Models.MobilizationList>> GetMobilizationListsAsync();
        Task<Domain.Models.MobilizationList> GetMobilizationListByIdAsync(int id);
        Task<bool> AddMobilizationListAsync(Domain.Models.MobilizationList mobilizationList);
        Task<bool> UpdateMobilizationListAsync(Domain.Models.MobilizationList mobilizationList);
        Task<bool> DeleteMobilizationListAsync(int id);
    }
}

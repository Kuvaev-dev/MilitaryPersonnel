using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IMobilizationListEntryRepository
    {
        Task<IEnumerable<MobilizationListEntry>> GetMobilizationListEntriesAsync();
        Task<MobilizationListEntry> GetMobilizationListEntryAsync(int id);
        Task<bool> AddMobilizationListEntryAsync(MobilizationListEntry entry);
        Task<bool> UpdateMobilizationListEntryAsync(MobilizationListEntry entry);
        Task<bool> DeleteMobilizationListEntryAsync(int id);
    }
}

namespace Domain.RepositoryAccess
{
    public interface IContactInfoRepository
    {
        Task<IEnumerable<Domain.Models.ContactInfo>> GetAllContactInfosAsync();
        Task<Domain.Models.ContactInfo> GetContactInfoByIdAsync(int id);
        Task<bool> AddContactInfoAsync(Domain.Models.ContactInfo contactInfo);
        Task<bool> UpdateContactInfoAsync(Domain.Models.ContactInfo contactInfo);
        Task<bool> DeleteContactInfoAsync(int id);
    }
}

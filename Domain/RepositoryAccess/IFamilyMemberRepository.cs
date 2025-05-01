using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IFamilyMemberRepository
    {
        Task<IEnumerable<FamilyMember>> GetAllFamilyMembersAsync();
        Task<FamilyMember?> GetFamilyMemberByIdAsync(int id);
        Task<bool> AddFamilyMemberAsync(FamilyMember familyMember);
        Task<bool> UpdateFamilyMemberAsync(FamilyMember familyMember);
        Task<bool> DeleteFamilyMemberAsync(int id);
    }
}

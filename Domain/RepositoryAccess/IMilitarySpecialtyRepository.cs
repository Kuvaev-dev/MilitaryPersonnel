using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IMilitarySpecialtyRepository
    {
        Task<IEnumerable<MilitarySpecialty>> GetAllAsync();
        Task<MilitarySpecialty?> GetByIdAsync(int id);
        Task<bool> AddAsync(MilitarySpecialty militarySpecialty);
        Task<bool> UpdateAsync(MilitarySpecialty militarySpecialty);
        Task<bool> DeleteAsync(int id);
    }
}

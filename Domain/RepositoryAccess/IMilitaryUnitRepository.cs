using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IMilitaryUnitRepository
    {
        Task<IEnumerable<MilitaryUnit>> GetAllMilitaryUnitsAsync();
        Task<MilitaryUnit?> GetMilitaryUnitByIdAsync(int id);
        Task<bool> AddMilitaryUnitAsync(MilitaryUnit militaryUnit);
        Task<bool> UpdateMilitaryUnitAsync(MilitaryUnit militaryUnit);
        Task<bool> DeleteMilitaryUnitAsync(int id);
    }
}

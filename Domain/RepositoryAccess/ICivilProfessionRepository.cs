namespace Domain.RepositoryAccess
{
    public interface ICivilProfessionRepository
    {
        Task<IEnumerable<Domain.Models.CivilProfession>> GetAllAsync();
        Task<Domain.Models.CivilProfession> GetByIdAsync(int id);
        Task<bool> AddAsync(Domain.Models.CivilProfession civilProfession);
        Task<bool> UpdateAsync(Domain.Models.CivilProfession civilProfession);
        Task<bool> DeleteAsync(int id);
    }
}

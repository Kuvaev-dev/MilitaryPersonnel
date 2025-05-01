namespace Domain.RepositoryAccess
{
    public interface IAwardRepository
    {
        Task<IEnumerable<Domain.Models.Award>> GetAllAwardsAsync();
        Task<Domain.Models.Award> GetAwardByIdAsync(int id);
        Task<bool> AddAwardAsync(Domain.Models.Award award);
        Task<bool> UpdateAwardAsync(Domain.Models.Award award);
        Task<bool> DeleteAwardAsync(int id);
    }
}

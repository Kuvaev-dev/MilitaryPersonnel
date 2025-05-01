using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task<bool> AddPositionAsync(Position position);
        Task<bool> UpdatePositionAsync(Position position);
        Task<bool> DeletePositionAsync(int id);
    }
}

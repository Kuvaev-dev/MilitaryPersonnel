using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public PositionRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPositionAsync(Position position)
        {
            var entity = new Positions
            {
                PositionName = position.PositionName,
            };

            _context.Positions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePositionAsync(int id)
        {
            var position = await GetPositionByIdAsync(id);
            if (position == null) return false;

            var positionEntity = new Positions
            {
                Id = position.Id,
                PositionName = position.PositionName,
            };

            _context.Positions.Remove(positionEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            var entities = await _context.Positions
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new Position
            {
                Id = a.Id,
                PositionName = a.PositionName,
            });
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            var entity = await _context.Positions
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Position
            {
                Id = entity.Id,
                PositionName = entity.PositionName,
            };
        }

        public async Task<bool> UpdatePositionAsync(Position position)
        {
            var entity = await _context.Positions.FindAsync(position.Id);
            if (entity == null) return false;

            entity.PositionName = position.PositionName;

            _context.Positions.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

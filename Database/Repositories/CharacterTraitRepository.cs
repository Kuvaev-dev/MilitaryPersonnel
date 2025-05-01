using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CharacterTraitRepository : ICharacterTraitRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public CharacterTraitRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<List<CharacterTrait>> GetAllCharacterTraitsAsync()
        {
            var entities = await _context.CharacterTraits
                .AsNoTracking()
                .ToListAsync();
            return entities.Select(ct => new CharacterTrait
            {
                Id = ct.Id,
                TraitName = ct.TraitName,
            }).ToList();
        }
        public async Task<CharacterTrait> GetCharacterTraitByIdAsync(int id)
        {
            var entity = await _context.CharacterTraits
                .AsNoTracking()
                .FirstOrDefaultAsync(ct => ct.Id == id);
            return entity == null ? null : new CharacterTrait
            {
                Id = entity.Id,
                TraitName = entity.TraitName,
            };
        }

        public async Task<bool> AddCharacterTraitAsync(CharacterTrait characterTrait)
        {
            var entity = new CharacterTraits
            {
                TraitName = characterTrait.TraitName,
            };
            _context.CharacterTraits.Add(entity);
            await _context.SaveChangesAsync();
            characterTrait.Id = entity.Id;
            return true;
        }

        public async Task<bool> UpdateCharacterTraitAsync(CharacterTrait characterTrait)
        {
            var entity = await _context.CharacterTraits.FindAsync(characterTrait.Id);
            if (entity == null) return false;
            entity.TraitName = characterTrait.TraitName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCharacterTraitAsync(int id)
        {
            var entity = await _context.CharacterTraits.FindAsync(id);
            if (entity == null) return false;
            _context.CharacterTraits.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

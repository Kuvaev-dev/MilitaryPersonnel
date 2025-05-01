namespace Domain.RepositoryAccess
{
    public interface ICharacterTraitRepository
    {
        Task<List<Domain.Models.CharacterTrait>> GetAllCharacterTraitsAsync();
        Task<Domain.Models.CharacterTrait> GetCharacterTraitByIdAsync(int id);
        Task<bool> AddCharacterTraitAsync(Domain.Models.CharacterTrait characterTrait);
        Task<bool> UpdateCharacterTraitAsync(Domain.Models.CharacterTrait characterTrait);
        Task<bool> DeleteCharacterTraitAsync(int id);
    }
}

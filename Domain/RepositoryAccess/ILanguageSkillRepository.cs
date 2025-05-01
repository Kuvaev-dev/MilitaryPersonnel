using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface ILanguageSkillRepository
    {
        Task<IEnumerable<LanguageSkill>> GetAllLanguageSkillsAsync();
        Task<LanguageSkill> GetLanguageSkillByIdAsync(int id);
        Task<bool> AddLanguageSkillAsync(LanguageSkill languageSkill);
        Task<bool> UpdateLanguageSkillAsync(LanguageSkill languageSkill);
        Task<bool> DeleteLanguageSkillAsync(int id);
    }
}

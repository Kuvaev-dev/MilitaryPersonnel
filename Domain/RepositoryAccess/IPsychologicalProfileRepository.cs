using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IPsychologicalProfileRepository
    {
        Task<IEnumerable<PsychologicalProfile>> GetAllPsychologicalProfilesAsync();
        Task<PsychologicalProfile?> GetPsychologicalProfileByIdAsync(int id);
        Task<PsychologicalProfile?> GetPsychologicalProfileByServicemanIdAsync(int servicemanId);
        Task<bool> AddPsychologicalProfileAsync(PsychologicalProfile psychologicalProfile);
        Task<bool> UpdatePsychologicalProfileAsync(PsychologicalProfile psychologicalProfile);
        Task<bool> DeletePsychologicalProfileAsync(int id);
    }
}

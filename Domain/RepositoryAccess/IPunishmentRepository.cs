namespace Domain.RepositoryAccess
{
    public interface IPunishmentRepository
    {
        Task<IEnumerable<Domain.Models.Punishment>> GetPunishmentsByServicemanId(int servicemanId);
        Task<IEnumerable<Domain.Models.Punishment>> GetAllPunishments();
        Task<Domain.Models.Punishment> GetPunishmentById(int punishmentId);
        Task<bool> AddPunishment(Domain.Models.Punishment punishment);
        Task<bool> UpdatePunishment(Domain.Models.Punishment punishment);
        Task<bool> DeletePunishment(int punishmentId);
    }
}

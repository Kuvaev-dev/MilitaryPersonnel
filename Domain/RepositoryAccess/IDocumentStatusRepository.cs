namespace Domain.RepositoryAccess
{
    public interface IDocumentStatusRepository
    {
        Task<IEnumerable<Domain.Models.DocumentStatus>> GetAllDocumentStatusesAsync();
        Task<Domain.Models.DocumentStatus> GetDocumentStatusByIdAsync(int id);
        Task<bool> AddDocumentStatusAsync(Domain.Models.DocumentStatus documentStatus);
        Task<bool> UpdateDocumentStatusAsync(Domain.Models.DocumentStatus documentStatus);
        Task<bool> DeleteDocumentStatusAsync(int id);
    }
}

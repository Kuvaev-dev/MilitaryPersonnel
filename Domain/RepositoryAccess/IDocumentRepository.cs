namespace Domain.RepositoryAccess
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Domain.Models.Document>> GetAllDocumentsAsync();
        Task<Domain.Models.Document> GetDocumentByIdAsync(int id);
        Task<bool> AddDocumentAsync(Domain.Models.Document document);
        Task<bool> UpdateDocumentAsync(Domain.Models.Document document);
        Task<bool> DeleteDocumentAsync(int id);
    }
}

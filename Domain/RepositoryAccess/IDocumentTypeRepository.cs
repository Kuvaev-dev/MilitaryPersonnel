namespace Domain.RepositoryAccess
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<Domain.Models.DocumentType>> GetAllDocumentTypesAsync();
        Task<Domain.Models.DocumentType> GetDocumentTypeByIdAsync(int id);
        Task<bool> AddDocumentTypeAsync(Domain.Models.DocumentType documentType);
        Task<bool> UpdateDocumentTypeAsync(Domain.Models.DocumentType documentType);
        Task<bool> DeleteDocumentTypeAsync(int id);
    }
}

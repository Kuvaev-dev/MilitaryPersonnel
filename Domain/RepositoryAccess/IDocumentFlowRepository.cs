namespace Domain.RepositoryAccess
{
    public interface IDocumentFlowRepository
    {
        Task<IEnumerable<Domain.Models.DocumentFlow>> GetAllDocumentFLowsAsync();
        Task<Domain.Models.DocumentFlow> GetDocumentFLowByIdAsync(int id);
        Task<bool> AddDocumentFLowAsync(Domain.Models.DocumentFlow document);
        Task<bool> UpdateDocumentFLowAsync(Domain.Models.DocumentFlow document);
        Task<bool> DeleteDocumentFLowAsync(int id);
        Task<bool> AssignDocumentAsync(int documentId, int assigneeId);
        Task<bool> ResolveDocumentAsync(int documentId, int authorId, string resolutionText);
        Task<IEnumerable<Domain.Models.DocumentAssignment>> GetDocumentAssignmentsAsync(int documentId);
        Task<bool> ApproveDocumentAsync(int documentId, int statusId);
        Task<bool> RejectDocumentAsync(int documentId, int statusId, string reason);
    }
}

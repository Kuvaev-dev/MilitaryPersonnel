namespace Domain.RepositoryAccess
{
    public interface IDocumentAssignmentRepository
    {
        Task<IEnumerable<Domain.Models.DocumentAssignment>> GetAllDocumentAssignmentsAsync();
        Task<Domain.Models.DocumentAssignment> GetDocumentAssignmentByIdAsync(int id);
        Task<bool> AddDocumentAssignmentAsync(Domain.Models.DocumentAssignment documentAssignment);
        Task<bool> UpdateDocumentAssignmentAsync(Domain.Models.DocumentAssignment documentAssignment);
        Task<bool> DeleteDocumentAssignmentAsync(int id);
        Task<IEnumerable<Domain.Models.DocumentAssignment>> GetDocumentAssignmentsByAssigneeIdAsync(int assigneeId);
        Task<IEnumerable<Domain.Models.DocumentAssignment>> GetDocumentAssignmentsByDocumentIdAsync(int documentId);
    }
}

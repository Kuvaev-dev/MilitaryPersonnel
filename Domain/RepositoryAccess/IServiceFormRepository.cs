namespace Domain.RepositoryAccess
{
    public interface IServiceFormRepository
    {
        Task<IEnumerable<Domain.Models.ServiceForm>> GetAllServiceFormsAsync();
        Task<Domain.Models.ServiceForm> GetServiceFormByIdAsync(int id);
        Task<bool> AddServiceFormAsync(Domain.Models.ServiceForm serviceForm);
        Task<bool> UpdateServiceFormAsync(Domain.Models.ServiceForm serviceForm);
        Task<bool> DeleteServiceFormAsync(int id);
    }
}

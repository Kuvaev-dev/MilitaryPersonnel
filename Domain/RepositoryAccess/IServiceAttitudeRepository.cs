using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IServiceAttitudeRepository
    {
        Task<IEnumerable<ServiceAttitude>> GetAllServiceAttitudesAsync();
        Task<ServiceAttitude> GetServiceAttitudeByIdAsync(int id);
        Task<bool> AddServiceAttitudeAsync(ServiceAttitude serviceAttitude);
        Task<bool> UpdateServiceAttitudeAsync(ServiceAttitude serviceAttitude);
        Task<bool> DeleteServiceAttitudeAsync(int id);
    }
}

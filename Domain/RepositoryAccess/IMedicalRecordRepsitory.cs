using Domain.Models;

namespace Domain.RepositoryAccess
{
    public interface IMedicalRecordRepsitory
    {
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync();
        Task<MedicalRecord> GetMedicalRecordByIdAsync(int id);
        Task<bool> AddMedicalRecordAsync(MedicalRecord medicalRecord);
        Task<bool> UpdateMedicalRecordAsync(MedicalRecord medicalRecord);
        Task<bool> DeleteMedicalRecordAsync(int id);
    }
}

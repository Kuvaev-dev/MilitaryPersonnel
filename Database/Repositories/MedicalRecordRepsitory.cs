using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class MedicalRecordRepsitory : IMedicalRecordRepsitory
    {
        private readonly MilitaryPersonnelContext _context;

        public MedicalRecordRepsitory(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            var entity = new MedicalRecords
            {
                ServicemanId = medicalRecord.ServicemanId,
                MedicalCondition = medicalRecord.MedicalCondition,
                RecordDate = medicalRecord.RecordDate,
            };

            _context.MedicalRecords.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMedicalRecordAsync(int id)
        {
            var medicalRecord = await GetMedicalRecordByIdAsync(id);
            if (medicalRecord == null) return false;

            var medicalRecordEntity = new MedicalRecords
            {
                Id = medicalRecord.Id,
                ServicemanId = medicalRecord.ServicemanId,
                MedicalCondition = medicalRecord.MedicalCondition,
                RecordDate = medicalRecord.RecordDate,
            };

            _context.MedicalRecords.Remove(medicalRecordEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync()
        {
            var entities = await _context.MedicalRecords
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .ToListAsync();

            return entities.Select(a => new MedicalRecord
            {
                Id = a.Id,
                ServicemanId = a.ServicemanId,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                MedicalCondition = a.MedicalCondition,
                RecordDate = a.RecordDate,
            });
        }

        public async Task<MedicalRecord> GetMedicalRecordByIdAsync(int id)
        {
            var entity = await _context.MedicalRecords
                .AsNoTracking()
                .Include(a => a.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new MedicalRecord
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                MedicalCondition = entity.MedicalCondition,
                RecordDate = entity.RecordDate,
            };
        }

        public async Task<bool> UpdateMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            var entity = await _context.MedicalRecords.FindAsync(medicalRecord.Id);
            if (entity == null) return false;

            entity.ServicemanId = medicalRecord.ServicemanId;
            entity.MedicalCondition = medicalRecord.MedicalCondition;
            entity.RecordDate = medicalRecord.RecordDate;

            _context.MedicalRecords.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ServicemanRepository : IServicemanRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ServicemanRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddServicemanAsync(Serviceman serviceman)
        {
            var entity = new Servicemen
            {
                FirstName = serviceman.FirstName,
                LastName = serviceman.LastName,
                MiddleName = serviceman.MiddleName,
                BirthDate = serviceman.BirthDate,
                CivilProfessionId = serviceman.CivilProfessionId,
                MilitarySpecialtyId = serviceman.MilitarySpecialtyId,
                EducationId = serviceman.EducationId,
                PositionId = serviceman.PositionId,
                SubdivisionId = serviceman.SubdivisionId,
                ServiceFormId = serviceman.ServiceFormId,
                CharacterTraitId = serviceman.CharacterTraitId,
                ServiceAttitudeId = serviceman.ServiceAttitudeId,
                Address = serviceman.Address,
                Phone = serviceman.Phone,
                Email = serviceman.Email,
                ServiceStatusId = serviceman.ServiceStatusId,
                FitnessCategoryId = serviceman.FitnessCategoryId,
                IsOfficer = serviceman.IsOfficer,
            };

            _context.Servicemen.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServicemanAsync(int id)
        {
            var serviceman = await GetServicemanByIdAsync(id);
            if (serviceman == null) return false;

            var servicemanEntity = new Servicemen
            {
                Id = serviceman.Id,
                FirstName = serviceman.FirstName,
                LastName = serviceman.LastName,
                MiddleName = serviceman.MiddleName,
                BirthDate = serviceman.BirthDate,
                CivilProfessionId = serviceman.CivilProfessionId,
                MilitarySpecialtyId = serviceman.MilitarySpecialtyId,
                EducationId = serviceman.EducationId,
                PositionId = serviceman.PositionId,
                SubdivisionId = serviceman.SubdivisionId,
                ServiceFormId = serviceman.ServiceFormId,
                CharacterTraitId = serviceman.CharacterTraitId,
                ServiceAttitudeId = serviceman.ServiceAttitudeId,
                Address = serviceman.Address,
                Phone = serviceman.Phone,
                Email = serviceman.Email,
                ServiceStatusId = serviceman.ServiceStatusId,
                FitnessCategoryId = serviceman.FitnessCategoryId,
                IsOfficer = serviceman.IsOfficer,
            };

            _context.Servicemen.Remove(servicemanEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Serviceman>> GetAllServicemenAsync()
        {
            var entities = await _context.Servicemen
                .AsNoTracking()
                .Include(a => a.CivilProfession)
                .Include(a => a.MilitarySpecialty)
                .Include(a => a.Education)
                .Include(a => a.Position)
                .Include(a => a.Subdivision)
                .Include(a => a.ServiceForm)
                .Include(a => a.CharacterTrait)
                .Include(a => a.ServiceAttitude)
                .Include(a => a.ServiceStatus)
                .Include(a => a.FitnessCategory)
                .ToListAsync();

            return entities.Select(a => new Serviceman
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                MiddleName = a.MiddleName,
                BirthDate = a.BirthDate,
                CivilProfessionId = a.CivilProfessionId,
                CivilProfession = a.CivilProfession?.ProfessionName,
                MilitarySpecialtyId = a.MilitarySpecialtyId,
                MilitarySpecialty = a.MilitarySpecialty?.SpecialtyName,
                EducationId = a.EducationId,
                Education = a.Education?.EducationLevel,
                PositionId = a.PositionId,
                Position = a.Position?.PositionName,
                SubdivisionId = a.SubdivisionId,
                Subdivision = a.Subdivision?.SubdivisionName,
                ServiceFormId = a.ServiceFormId,
                ServiceForm = a.ServiceForm?.FormName,
                CharacterTraitId = a.CharacterTraitId,
                CharacterTrait = a.CharacterTrait?.TraitName,
                ServiceAttitudeId = a.ServiceAttitudeId,
                ServiceAttitude = a.ServiceAttitude?.AttitudeDescription,
                Address = a.Address,
                Phone = a.Phone,
                Email = a.Email,
                ServiceStatusId = a.ServiceStatusId,
                ServiceStatus = a.ServiceStatus?.StatusName,
                FitnessCategoryId = a.FitnessCategoryId,
                FitnessCategory = a.FitnessCategory?.CategoryName,
                IsOfficer = a.IsOfficer,
            });
        }

        public async Task<Serviceman?> GetServicemanByIdAsync(int id)
        {
            var entity = await _context.Servicemen
                .AsNoTracking()
                .Include(a => a.CivilProfession)
                .Include(a => a.MilitarySpecialty)
                .Include(a => a.Education)
                .Include(a => a.Position)
                .Include(a => a.Subdivision)
                .Include(a => a.ServiceForm)
                .Include(a => a.CharacterTrait)
                .Include(a => a.ServiceAttitude)
                .Include(a => a.ServiceStatus)
                .Include(a => a.FitnessCategory)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new Serviceman
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                BirthDate = entity.BirthDate,
                CivilProfessionId = entity.CivilProfessionId,
                CivilProfession = entity.CivilProfession?.ProfessionName,
                MilitarySpecialtyId = entity.MilitarySpecialtyId,
                MilitarySpecialty = entity.MilitarySpecialty?.SpecialtyName,
                EducationId = entity.EducationId,
                Education = entity.Education?.EducationLevel,
                PositionId = entity.PositionId,
                Position = entity.Position?.PositionName,
                SubdivisionId = entity.SubdivisionId,
                Subdivision = entity.Subdivision?.SubdivisionName,
                ServiceFormId = entity.ServiceFormId,
                ServiceForm = entity.ServiceForm?.FormName,
                CharacterTraitId = entity.CharacterTraitId,
                CharacterTrait = entity.CharacterTrait?.TraitName,
                ServiceAttitudeId = entity.ServiceAttitudeId,
                ServiceAttitude = entity.ServiceAttitude?.AttitudeDescription,
                Address = entity.Address,
                Phone = entity.Phone,
                Email = entity.Email,
                ServiceStatusId = entity.ServiceStatusId,
                ServiceStatus = entity.ServiceStatus?.StatusName,
                FitnessCategoryId = entity.FitnessCategoryId,
                FitnessCategory = entity.FitnessCategory?.CategoryName,
                IsOfficer = entity.IsOfficer,
            };
        }

        public async Task<IEnumerable<Serviceman>> GetServicemenBySubdivisionIdAsync(int subdivisionId)
        {
            var entities = await _context.Servicemen
                .AsNoTracking()
                .Include(a => a.CivilProfession)
                .Include(a => a.MilitarySpecialty)
                .Include(a => a.Education)
                .Include(a => a.Position)
                .Include(a => a.Subdivision)
                .Include(a => a.ServiceForm)
                .Include(a => a.CharacterTrait)
                .Include(a => a.ServiceAttitude)
                .Include(a => a.ServiceStatus)
                .Include(a => a.FitnessCategory)
                .Where(ac => ac.SubdivisionId == subdivisionId)
                .ToListAsync();

            return entities.Select(a => new Serviceman
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                MiddleName = a.MiddleName,
                BirthDate = a.BirthDate,
                CivilProfessionId = a.CivilProfessionId,
                CivilProfession = a.CivilProfession?.ProfessionName,
                MilitarySpecialtyId = a.MilitarySpecialtyId,
                MilitarySpecialty = a.MilitarySpecialty?.SpecialtyName,
                EducationId = a.EducationId,
                Education = a.Education?.EducationLevel,
                PositionId = a.PositionId,
                Position = a.Position?.PositionName,
                SubdivisionId = a.SubdivisionId,
                Subdivision = a.Subdivision?.SubdivisionName,
                ServiceFormId = a.ServiceFormId,
                ServiceForm = a.ServiceForm?.FormName,
                CharacterTraitId = a.CharacterTraitId,
                CharacterTrait = a.CharacterTrait?.TraitName,
                ServiceAttitudeId = a.ServiceAttitudeId,
                ServiceAttitude = a.ServiceAttitude?.AttitudeDescription,
                Address = a.Address,
                Phone = a.Phone,
                Email = a.Email,
                ServiceStatusId = a.ServiceStatusId,
                ServiceStatus = a.ServiceStatus?.StatusName,
                FitnessCategoryId = a.FitnessCategoryId,
                FitnessCategory = a.FitnessCategory?.CategoryName,
                IsOfficer = a.IsOfficer,
            });
        }

        public async Task<bool> UpdateServicemanAsync(Serviceman serviceman)
        {
            var entity = await _context.Servicemen.FindAsync(serviceman.Id);
            if (entity == null) return false;

            entity.FirstName = serviceman.FirstName;
            entity.LastName = serviceman.LastName;
            entity.MiddleName = serviceman.MiddleName;
            entity.BirthDate = serviceman.BirthDate;
            entity.CivilProfessionId = serviceman.CivilProfessionId;
            entity.MilitarySpecialtyId = serviceman.MilitarySpecialtyId;
            entity.EducationId = serviceman.EducationId;
            entity.PositionId = serviceman.PositionId;
            entity.SubdivisionId = serviceman.SubdivisionId;
            entity.ServiceFormId = serviceman.ServiceFormId;
            entity.CharacterTraitId = serviceman.CharacterTraitId;
            entity.ServiceAttitudeId = serviceman.ServiceAttitudeId;
            entity.Address = serviceman.Address;
            entity.Phone = serviceman.Phone;
            entity.Email = serviceman.Email;
            entity.ServiceStatusId = serviceman.ServiceStatusId;
            entity.FitnessCategoryId = serviceman.FitnessCategoryId;
            entity.IsOfficer = serviceman.IsOfficer;

            _context.Servicemen.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

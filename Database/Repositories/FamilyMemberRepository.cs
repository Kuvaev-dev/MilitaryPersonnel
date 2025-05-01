using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class FamilyMemberRepository : IFamilyMemberRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public FamilyMemberRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFamilyMemberAsync(FamilyMember familyMember)
        {
            var entity = new FamilyMembers
            {
                FullName = familyMember.FullName,
                Relationship = familyMember.Relationship,
                BirthDate = familyMember.BirthDate,
                ServicemanId = familyMember.ServicemanId,
            };

            _context.FamilyMembers.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFamilyMemberAsync(int id)
        {
            var familyMember = await GetFamilyMemberByIdAsync(id);
            if (familyMember == null) return false;

            var familyMemberEntity = new FamilyMembers
            {
                Id = familyMember.Id,
                FullName = familyMember.FullName,
                Relationship = familyMember.Relationship,
                BirthDate = familyMember.BirthDate,
                ServicemanId = familyMember.ServicemanId,
            };

            _context.FamilyMembers.Remove(familyMemberEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FamilyMember>> GetAllFamilyMembersAsync()
        {
            var entities = await _context.FamilyMembers
                .AsNoTracking()
                .Include(s => s.Serviceman)
                .ToListAsync();

            return entities.Select(a => new FamilyMember
            {
                Id = a.Id,
                ServicemenFullName = a.Serviceman?.LastName + " " + a.Serviceman?.FirstName + " " + a.Serviceman?.MiddleName,
                FullName = a.FullName,
                Relationship = a.Relationship,
                BirthDate = a.BirthDate,
                ServicemanId = a.ServicemanId,
            });
        }

        public async Task<FamilyMember?> GetFamilyMemberByIdAsync(int id)
        {
            var entity = await _context.FamilyMembers
                .AsNoTracking()
                .Include(s => s.Serviceman)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new FamilyMember
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Relationship = entity.Relationship,
                BirthDate = entity.BirthDate,
                ServicemanId = entity.ServicemanId,
                ServicemenFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
            };
        }

        public async Task<bool> UpdateFamilyMemberAsync(FamilyMember familyMember)
        {
            var entity = await _context.FamilyMembers.FindAsync(familyMember.Id);
            if (entity == null) return false;

            entity.FullName = familyMember.FullName;
            entity.Relationship = familyMember.Relationship;
            entity.BirthDate = familyMember.BirthDate;
            entity.ServicemanId = familyMember.ServicemanId;

            _context.FamilyMembers.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

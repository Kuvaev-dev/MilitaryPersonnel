using Database.Context;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ContactInfoRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.ContactInfo>> GetAllContactInfosAsync()
        {
            var entities = await _context.ContactInfo.Include(s => s.Serviceman).ToListAsync();
            return entities.Select(c => new Domain.Models.ContactInfo
            {
                Id = c.Id,
                ServicemanId = c.ServicemanId,
                ServicemanFullName = c.Serviceman?.LastName + " " + c.Serviceman?.FirstName + " " + c.Serviceman?.MiddleName,
                Phone = c.Phone,
                Email = c.Email,
                Address = c.Address
            }).ToList();
        }

        public async Task<Domain.Models.ContactInfo> GetContactInfoByIdAsync(int id)
        {
            var entity = await _context.ContactInfo.FindAsync(id);

            return new Domain.Models.ContactInfo
            {
                Id = entity.Id,
                ServicemanId = entity.ServicemanId,
                ServicemanFullName = entity.Serviceman?.LastName + " " + entity.Serviceman?.FirstName + " " + entity.Serviceman?.MiddleName,
                Phone = entity.Phone,
                Email = entity.Email,
                Address = entity.Address
            };
        }

        public async Task<bool> AddContactInfoAsync(Domain.Models.ContactInfo contactInfo)
        {
            var entity = new Models.ContactInfo
            {
                ServicemanId = contactInfo.ServicemanId,
                Phone = contactInfo.Phone,
                Email = contactInfo.Email,
                Address = contactInfo.Address
            };

            _context.ContactInfo.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateContactInfoAsync(Domain.Models.ContactInfo contactInfo)
        {
            var entity = await _context.ContactInfo.FindAsync(contactInfo.Id);
            if (entity == null) return false;

            entity.Phone = contactInfo.Phone;
            entity.Email = contactInfo.Email;
            entity.Address = contactInfo.Address;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContactInfoAsync(int id)
        {
            var entity = await _context.ContactInfo.FindAsync(id);
            if (entity == null) return false;
            _context.ContactInfo.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

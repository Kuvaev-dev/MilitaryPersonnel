using Database.Context;
using Database.Models;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class ServiceFormRepository : IServiceFormRepository
    {
        private readonly MilitaryPersonnelContext _context;

        public ServiceFormRepository(MilitaryPersonnelContext context)
        {
            _context = context;
        }

        public async Task<bool> AddServiceFormAsync(ServiceForm serviceForm)
        {
            var entity = new ServiceForms
            {
                FormName = serviceForm.FormName,
            };

            _context.ServiceForms.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceFormAsync(int id)
        {
            var serviceForm = await GetServiceFormByIdAsync(id);
            if (serviceForm == null) return false;

            var serviceFormEntity = new ServiceForms
            {
                Id = serviceForm.Id,
                FormName = serviceForm.FormName,
            };

            _context.ServiceForms.Remove(serviceFormEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceForm>> GetAllServiceFormsAsync()
        {
            var entities = await _context.ServiceForms
                .AsNoTracking()
                .ToListAsync();

            return entities.Select(a => new ServiceForm
            {
                Id = a.Id,
                FormName = a.FormName,
            });
        }

        public async Task<ServiceForm> GetServiceFormByIdAsync(int id)
        {
            var entity = await _context.ServiceForms
                .AsNoTracking()
                .FirstOrDefaultAsync(ac => ac.Id == id);

            return entity == null ? null : new ServiceForm
            {
                Id = entity.Id,
                FormName = entity.FormName,
            };
        }

        public async Task<bool> UpdateServiceFormAsync(ServiceForm serviceForm)
        {
            var entity = await _context.ServiceForms.FindAsync(serviceForm.Id);
            if (entity == null) return false;

            entity.FormName = serviceForm.FormName;

            _context.ServiceForms.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

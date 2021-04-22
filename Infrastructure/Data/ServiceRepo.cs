using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly ShopContext _context;
        public ServiceRepo(ShopContext context)
        {
            _context = context;
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services
            .Include(s => s.ServiceType)
            .Include(s => s.CommType)
            .Include(s => s.DesignOptions)
            .FirstOrDefaultAsync(s => s.Id == id); //do the same as findasync(id)
        }

        public async Task<IReadOnlyList<Service>> GetServicesAsync()
        {
            return await _context.Services
                     .Include(s => s.ServiceType)
                     .Include(s => s.CommType)
                     .Include(s => s.DesignOptions)
                     .ToListAsync();
        }

        public async Task<IReadOnlyList<ServiceType>> GetServiceTypesAsync()
        {
            return await _context.ServiceTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<CommType>> GetCommTypesAsync()
        {
            return await _context.CommTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<DesignOption>> GetDesignOptionsAsync()
        {
            return await _context.DesignOptions.ToListAsync();
        }
    }
}
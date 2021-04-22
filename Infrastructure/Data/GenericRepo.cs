using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Core.Spec;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly ShopContext _context;
        public GenericRepo(ShopContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpec<T> spec)
        {
            return await ApplySpec(spec).ToListAsync();
        }
        public async Task<T> GetEntityWithSpec(ISpec<T> spec)
        {
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpec(ISpec<T> spec)
        {
            return SpecEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
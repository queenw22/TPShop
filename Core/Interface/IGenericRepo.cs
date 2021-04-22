using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Spec;

namespace Core.Interface
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpec<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpec<T> spec);

                
    }
}
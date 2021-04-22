using System.Linq;
using Core.Entity;
using Core.Spec;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpec<TEntity> spec)
        {
            var query = inputQuery;
            
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // t => t.ServiceTypeIf == id
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
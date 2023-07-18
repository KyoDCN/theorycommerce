using Microsoft.EntityFrameworkCore;
using TheoryCommerce.Core.Entities;
using TheoryCommerce.Core.Specifications;

namespace TheoryCommerce.Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> spec)
        {
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return spec.Includes.Aggregate(query, (totalExp, currExp) => totalExp.Include(currExp)); ;
        }
    }
}

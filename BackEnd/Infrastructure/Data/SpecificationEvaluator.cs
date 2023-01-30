using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static QueryWithAdditionalDataAfterSpecification<T> GetQuery(
            IQueryable<T> inputQuery,
            ISpecification<T> specification
        )
        {
            IQueryable<T> query = inputQuery;
            int numberOfSpecifiedObjectsInDB = 0;
            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(
                query,
                (current, include) => current.Include(include)
            );
            numberOfSpecifiedObjectsInDB = query.Count();


            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return new QueryWithAdditionalDataAfterSpecification<T>(numberOfSpecifiedObjectsInDB, query);
        }
    }
}

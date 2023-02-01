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

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.Includes.Aggregate(
                query,
                (current, include) => current.Include(include)
            );
            numberOfSpecifiedObjectsInDB = query.Count();

            return new QueryWithAdditionalDataAfterSpecification<T>(
                numberOfSpecifiedObjectsInDB,
                query
            );
        }
    }
}

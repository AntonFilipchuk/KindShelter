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
            
            //Count number of specified entities for pagination
            //Need to count them before ordering!
            numberOfSpecifiedObjectsInDB = query.Count();


            //Order specified entities
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

            return new QueryWithAdditionalDataAfterSpecification<T>(
                numberOfSpecifiedObjectsInDB,
                query
            );
        }
    }
}

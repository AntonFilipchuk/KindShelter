using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Helpers
{
    public class QueryWithAdditionalDataAfterSpecification<T> where T : BaseEntity
    {
        public QueryWithAdditionalDataAfterSpecification(
            int numberOfSpecifiedObjectsInDB,
            IQueryable<T> query
        )
        {
            Query = query;
            NumberOfSpecifiedObjectsInDB = numberOfSpecifiedObjectsInDB;
        }

        public int NumberOfSpecifiedObjectsInDB { get; private set; }
        public IQueryable<T> Query { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ShelterContext _context;

        public GenericRepository(ShelterContext context)
        {
            _context = context;
        }

        public async Task<DataForPagination<T>> GetEntitiesBySpecForPaginationAsync(ISpecification<T> specification)
        {
            QueryWithAdditionalDataAfterSpecification<T> data =  ApplySpecification(specification);
            return new DataForPagination<T>(data.NumberOfSpecifiedObjectsInDB, await data.Query.ToListAsync());
        }

        public async Task<T?> GetEntityBySpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).Query.FirstOrDefaultAsync();
        } 

        private QueryWithAdditionalDataAfterSpecification<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(
                _context.Set<T>().AsQueryable(),
                specification
            );
        }
    }
}

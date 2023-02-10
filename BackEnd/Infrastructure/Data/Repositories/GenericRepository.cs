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

        public async Task<IEnumerable<T>> GetEntities()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<DataForPagination<T>> GetEntitiesBySpecForPaginationAsync(
            ISpecification<T> specification
        )
        {
            QueryWithAdditionalDataAfterSpecification<T> queryWithAdditionalData =
                ApplySpecification(specification);
            return new DataForPagination<T>(
                queryWithAdditionalData.NumberOfSpecifiedObjectsInDB,
                await queryWithAdditionalData.Query.ToListAsync()
            );
        }

        public async Task<T?> GetEntityBySpecAsync(ISpecification<T> specification)
        {
            QueryWithAdditionalDataAfterSpecification<T> queryWithAdditionalData =
                ApplySpecification(specification);
            if (queryWithAdditionalData.NumberOfSpecifiedObjectsInDB == 0)
            {
                return null;
            }
            return await ApplySpecification(specification).Query.FirstOrDefaultAsync();
        }

        public async Task<T?> AddEntity(T entity)
        {
            //check if item with the same id exists
            var item = _context
                .Set<T>()
                .Where(entityInSet => entityInSet.Id == entity.Id)
                .SingleOrDefaultAsync();

            if (item is not null)
            {
                return null;
            }
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        private QueryWithAdditionalDataAfterSpecification<T> ApplySpecification(
            ISpecification<T> specification
        )
        {
            return SpecificationEvaluator<T>.GetQuery(
                _context.Set<T>().AsQueryable(),
                specification
            );
        }
    }
}

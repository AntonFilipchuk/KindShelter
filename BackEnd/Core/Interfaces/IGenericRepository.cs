using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<DataForPagination<T>> GetEntitiesBySpecForPaginationAsync(ISpecification<T> specification);
        Task<T?> GetEntityBySpec(ISpecification<T> specification);
        Task<T?> AddEntity(T entity);
    }
}

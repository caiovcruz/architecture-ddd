using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArchitectureDDD.Domain
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null);
    }
}

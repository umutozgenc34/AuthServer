

using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Core.Repository;

public interface IGenericRepository<TEntity,TId> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    ValueTask<TEntity?> GetByIdAsync(TId id);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    ValueTask AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}

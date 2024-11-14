

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repository;

public class GenericRepository<TContext, TEntity,TId>(TContext context) : IGenericRepository<TEntity,TId>
    where TEntity : class, new()
    where TContext : DbContext
{
    protected TContext Context { get; } = context;

    public IQueryable<TEntity> GetAll() => Context.Set<TEntity>().AsNoTracking();

    public ValueTask<TEntity?> GetByIdAsync(TId id) => Context.Set<TEntity>().FindAsync(id);

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return predicate is null
            ? GetAll()
            : Context.Set<TEntity>().Where(predicate);
    }

    public async ValueTask AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);

   

    
}

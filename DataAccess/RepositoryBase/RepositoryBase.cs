using System.Linq.Expressions;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class RepositoryBase<TEntity,TContext> : IRepositoryBase<TEntity> where TEntity :class,IEntity ,new() where TContext : DbContext, new()
{
    public Task AddAsync(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var entry = context.Entry(entity);
            entry.State = EntityState.Added;
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext())
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }   
    }
}
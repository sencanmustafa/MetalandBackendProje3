using System.Linq.Expressions;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class RepositoryBase<TEntity,TContext> : IRepositoryBase<TEntity> where TEntity :class,IEntity ,new() where TContext : DbContext, new()
{
    public Task AddAsync(TEntity entity)
    {
        using (var context = new TContext())
        {
            //var entry = context.Entry(entity);
            //entry.State = EntityState.Added;
            //context.SaveChanges();
            //return Task.CompletedTask;
            var entry = context.Entry(entity);
            entry.State = EntityState.Added;

            // Add related entities if available
            var users = entity as Users;
            if (users != null)
            {
                foreach (var money in users.Money)
                {
                    var moneyEntry = context.Entry(money);
                    moneyEntry.State = EntityState.Added;
                }

                foreach (var food in users.Foods)
                {
                    var foodEntry = context.Entry(food);
                    foodEntry.State = EntityState.Added;
                }

                foreach (var stuff in users.Stuff)
                {
                    var stuffEntry = context.Entry(stuff);
                    stuffEntry.State = EntityState.Added;
                }
            }

            context.SaveChanges();
            return Task.CompletedTask;
        }
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        await using (var context = new TContext())
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }   
    }
}
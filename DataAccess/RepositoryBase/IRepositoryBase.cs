using System.Linq.Expressions;
using Entity;

namespace DataAccess;

public interface IRepositoryBase<TEntity> where TEntity : IEntity
{
    public Task AddAsync(TEntity entity);
    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    
    
}
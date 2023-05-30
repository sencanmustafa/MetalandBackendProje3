using Entity;

namespace DataAccess;

public interface IUserDal : IRepositoryBase<Users>
{ 
    public Task<ICollection<Users>> GetALl();
}
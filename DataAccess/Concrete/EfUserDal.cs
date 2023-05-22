using DataAccess.EntityFramework;
using Entity;

namespace DataAccess;

public class EfUserDal : RepositoryBase<Users,MetalandDbContext>,IUserDal
{
    
}
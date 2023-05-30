using DataAccess.EntityFramework;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class EfUserDal : RepositoryBase<Users,MetalandDbContext>,IUserDal
{
    public async Task<ICollection<Users>> GetALl()
    {
        using (MetalandDbContext context = new MetalandDbContext())
        {
            var result = await context.Users.ToListAsync();
            return result;
        }
    }
}
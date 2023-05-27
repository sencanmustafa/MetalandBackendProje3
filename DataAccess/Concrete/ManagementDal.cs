using DataAccess.EntityFramework;
using Entity;

namespace DataAccess;

public class ManagementDal:RepositoryBase<Management,MetalandDbContext>,IManagementDal
{
    
}
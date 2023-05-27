using DataAccess.EntityFramework;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ManagementDal:RepositoryBase<Management,MetalandDbContext>,IManagementDal
{
    public async Task<Management> GetManagementById(int managementId)
    {
        using (MetalandDbContext context = new MetalandDbContext())
        {
            var result = await context.Management.FirstOrDefaultAsync(i => i.Id == managementId);
            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new Exception("Cant Find");
            };
        }
    }

    public async Task AddManagementSell(ManagementSaleRentDetails management)
    {
        using (MetalandDbContext context = new MetalandDbContext())
        {
            await context.ManagementSaleRentDetails.AddAsync(management);
        }
    }
}
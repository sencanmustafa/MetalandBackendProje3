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
            var result = await context.Management.SingleOrDefaultAsync(i => i.Id == managementId);
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
        try
        {
            using (MetalandDbContext context = new MetalandDbContext())
            {
                await context.ManagementSaleRentDetails.AddAsync(management);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {

            await Console.Out.WriteLineAsync(e.Message);
        }
        
    }
}
using Entity;

namespace DataAccess;

public interface IManagementDal : IRepositoryBase<Management>
{
    public Task<Management> GetManagementById(int managementId);
    public Task AddManagementSell(ManagementSaleRentDetails management);
}
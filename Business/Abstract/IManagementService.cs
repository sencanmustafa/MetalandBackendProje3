using Entity;
using Entity.Dto;

namespace Business.Abstract;

public interface IManagementService
{
    public Task CreateManagement(ManagementDto managementDto);
    public Task DeleteManagement(int managementId);
    public Task RentManagement(int userId,int managementId);
    public Task SellManagement(int userId,int managementId);
    
    public Task<Management> CastManagementDto(ManagementDto managementDto);

    public Task<Management> GetManagementAsync(int managementId);
}
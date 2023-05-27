using Entity;
using Entity.Dto;

namespace Business.Abstract;

public interface IManagementService
{
    public Task CreateManagement(ManagementDto managementDto);
    public Task DeleteManagement(int managementId);
    public Task RentManagement(int managementId);
    public Task SellManagement(int managementId);
    
    public Task<Management> CastManagementDto(ManagementDto managementDto);
    
}
using Business.Abstract;
using DataAccess;
using Entity;
using Entity.Dto;

namespace Business.Concrete;

public class ManagementManager : IManagementService
{
    private readonly IManagementDal _managementDal;

    public ManagementManager(IManagementDal managementDal)
    {
        _managementDal = managementDal;
    }

    public async Task CreateManagement(ManagementDto managementDto)
    {
        var management = await CastManagementDto(managementDto);
        await _managementDal.AddAsync(management);
    }

    public Task DeleteManagement(int managementId)
    {
        throw new NotImplementedException();
    }

    public Task RentManagement(int userId,int managementId)
    {
        throw new NotImplementedException();
    }

    public async Task SellManagement(int userId,int managementId)
    {
        var selectedManagement = await GetManagementAsync(managementId);
        var sellEntity = await CreateNewSellEntity(userId, selectedManagement);
        await _managementDal.AddManagementSell(sellEntity);
    }

    private Task<ManagementSaleRentDetails> CreateNewSellEntity(int userId, Management selectedManagement)
    {
        var entity = new ManagementSaleRentDetails()
        {
            Management = selectedManagement,
            ManagementId = selectedManagement.Id,
            UserId = userId
        };
        return Task.FromResult(entity);
    }

    public Task<Management> CastManagementDto(ManagementDto managementDto)
    {
        Management management = new Management
        {
            Type = managementDto.Type,
            AdminCost = managementDto.AdminCost,
            UserCost = managementDto.UserCost,
            UserStartDate = managementDto.UserStartDate,
            UserEndDate = managementDto.UserEndDate,
            UserWorkedDayCount = managementDto.UserWorkedDayCount,
            UserCasualWorkTime = managementDto.UserCasualWorkTime,
            ManagementDetails = new List<ManagementDetails>()
        };

        foreach (var managementDetailsDto in managementDto.ManagementDetails)
        {
            ManagementDetails managementDetails = new ManagementDetails
            {
                Id = managementDetailsDto.Id,
                ManagementId = managementDetailsDto.ManagementId,
                ManagementLevel = managementDetailsDto.ManagementLevel,
                ManagementCapacity = managementDetailsDto.ManagementCapacity,
                ManagementWorkerCount = managementDetailsDto.ManagementWorkerCount,
                ManagementFoodPrice = managementDetailsDto.ManagementFoodPrice,
                ManagementStuffPrice = managementDetailsDto.ManagementStuffPrice,
                ManagementCommission = managementDetailsDto.ManagementCommission,
                ManagementRentTime = managementDetailsDto.ManagementRentTime,
                ManagementSellDate = managementDetailsDto.ManagementSellDate,
                ManagementRentDate = managementDetailsDto.ManagementRentDate
            };

            management.ManagementDetails.Add(managementDetails);
        }

        return Task.FromResult(management);
    }

    public async Task<Management> GetManagementAsync(int managementId)
    {
        var result = await _managementDal.GetAsync(i => i.Id == managementId);
        return result;
    }
}
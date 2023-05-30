using Entity;
using Entity.Dto;

namespace Business.Abstract;

public interface IAdminService : IUserService
{
    public Task<ICollection<Users>> GetAllUsers();
}
using Entity;
using Entity.Dto;

namespace Business.Abstract;

public interface IUserService
{
    public Task AddAsync(UserDto userDto);
    public Task<Users> GetUserAsync(int userId);

    public Task<Users> CreateNewUser(UserDto userDto);
}
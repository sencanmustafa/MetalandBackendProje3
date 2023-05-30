using Entity;
using Entity.Dto;

namespace Business.Abstract;

public interface IUserService
{
    public Task AddAsync(UserRegisterDto userRegisterDto);
    public Task<Users> GetUserAsync(int userId);

    public Task<Users> CreateNewUser(UserRegisterDto userRegisterDto);

    public string Login(UserLoginDto userLoginDto);

}
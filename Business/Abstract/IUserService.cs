using Entity;

namespace Business.Abstract;

public interface IUserService
{
    public Task<int> AddAsync(Users newUser);
    public Task<Users> GetUserAsync(int userId);
}
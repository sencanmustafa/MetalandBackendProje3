using Business.Abstract;
using DataAccess;
using Entity;

namespace Business.Concrete;

public class UserManager : IUserService
{

    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }


    public async Task<int> AddAsync(Users newUser)
    {
        await _userDal.AddAsync(newUser);
        return 1;
    }

    public async Task<Users> GetUserAsync(int userId)
    {
        var result = await _userDal.GetAsync(p => p.UserId == userId);
        return result;
    }
}
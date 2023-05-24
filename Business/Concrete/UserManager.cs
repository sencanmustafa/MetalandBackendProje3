using Business.Abstract;
using DataAccess;
using Entity;
using Entity.Dto;

namespace Business.Concrete;

public class UserManager : IUserService
{

    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }


    public async Task AddAsync(UserDto userDto)
    {
        var newUser = await CreateNewUser(userDto);
        await _userDal.AddAsync(newUser);
    }

    public async Task<Users> GetUserAsync(int userId)
    {
        var result = await _userDal.GetAsync(p => p.UserId == userId);
        return result;
    }

    public Task<Users> CreateNewUser(UserDto userDto)
    {
        Users newUser = new Users()
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            Password = userDto.Password,
        };
        newUser.Money = new List<Money>()
        {
            new Money
            {
                UserId = newUser.UserId, 
                Count = 0.0f,
                User = newUser
            }
        };
        newUser.Foods = new List<Food>()
        {
            new Food
            {
                UserId = newUser.UserId,
                Count = 0,
                User = newUser
            }
        };
        newUser.Stuff = new List<Stuff>()
        {
            new Stuff
            {
                UserId = newUser.UserId,
                Count = 0.0f,
                User = newUser
            }
        };
        
        return Task.FromResult(newUser);
    }
}
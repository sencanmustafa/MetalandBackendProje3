using Business.Abstract;
using DataAccess;
using Entity;
using Entity.Dto;

namespace Business.Concrete;

public class AdminManager : UserManager,IAdminService
{
    private readonly IUserDal _userDal;
    public AdminManager(IUserDal userDal) : base(userDal)
    {
        _userDal = userDal;
    }

    
    public Task<ICollection<Users>> GetAllUsers()
    {
        var result = _userDal.GetALl();
        return result;
    }
}
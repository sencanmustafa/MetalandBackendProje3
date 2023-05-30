using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Abstract;
using DataAccess;
using Entity;
using Entity.Dto;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete;

public class UserManager : IUserService
{

    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }


    public async Task AddAsync(UserRegisterDto userRegisterDto)
    {
        var newUser = await CreateNewUser(userRegisterDto);
        await _userDal.AddAsync(newUser);
    }

    public async Task<Users> GetUserAsync(int userId)
    {
        var result = await _userDal.GetAsync(p => p.UserId == userId);
        return result;
    }

    public Task<Users> CreateNewUser(UserRegisterDto userRegisterDto)
    {
        Users newUser = new Users()
        {
            Name = userRegisterDto.Name,
            Surname = userRegisterDto.Surname,
            Password = userRegisterDto.Password,
        };
        newUser.Money = new List<Money>()
        {
            new Money
            {
                UserId = newUser.UserId, 
                Count = 30,
                User = newUser
            }
        };
        newUser.Foods = new List<Food>()
        {
            new Food
            {
                UserId = newUser.UserId,
                Count = 10,
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
    private const string secretKey = "thisIsA64CharactersLongSecretKeyForHmacShdfgsdfgsdgasdfazsdfasdfasdfgasdfvbasdvzsxdgfvqsf2q34r1234rwertfaxfgbaa512Signature12345";
    public string CreateAccessToken(Users user)
    {
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            
        var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        var claims = new List<Claim>();
        claims.Add(new Claim("userId",user.UserId.ToString()));
        claims.Add(new Claim(ClaimTypes.Role, "standartToken"));

        var tokenHandler = new JwtSecurityToken
        (
            issuer: "www.tmCarbon.app",
            audience: "www.tmCarbon.app",
            expires : DateTime.UtcNow.AddDays(1000),
            signingCredentials : signingCredential,
            claims : claims
        );
        var token = new JwtSecurityTokenHandler().WriteToken(tokenHandler);

        return token;
            
    }
    
    public string CreateAdminAccessToken(Users user)
    {
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            
        var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

        var claims = new List<Claim>();
        claims.Add(new Claim("userId",user.UserId.ToString()));
        claims.Add(new Claim(ClaimTypes.Role, "admin"));

        var tokenHandler = new JwtSecurityToken
        (
            issuer: "www.tmCarbon.app",
            audience: "www.tmCarbon.app",
            expires : DateTime.UtcNow.AddDays(1000),
            signingCredentials : signingCredential,
            claims : claims
        );
        var token = new JwtSecurityTokenHandler().WriteToken(tokenHandler);

        return token;
            
    }
    
    public string Login(UserLoginDto userLoginDto)
    {
        var result = _userDal.GetAsync(x => x.Name == userLoginDto.Name);
        if (result is null)
        {
            return "user not found";
        }

        if (result.Result.Password!=userLoginDto.Password)
        {
            return "wrong credential";
        }

        if (result.Result.Role == 1)
        {
            var adminToken = CreateAdminAccessToken(result.Result);
            return adminToken;
        }
        else
        {
            var token = CreateAccessToken(result.Result);
            return token;
        }
        

    }



}
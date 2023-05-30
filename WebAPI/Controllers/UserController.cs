using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        public UserController(IUserService userService,IAdminService adminService)
        {
            _userService = userService;
            _adminService = adminService;
        }


        [HttpGet]
        [Route("getById")]
        
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            try
            {
                var result = await _userService.GetUserAsync(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                await _userService.AddAsync(userRegisterDto);
                return Ok(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("loginUser")]
        public Dictionary<string,string> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var token = _userService.Login(userLoginDto);
                Log.Information($"{userLoginDto.Name} logged in");
                return new Dictionary<string,string>{{"token",token}};
            }
            catch (Exception e)
            {
                return new Dictionary<string,string>{{"error",e.Message}};
            }
        }
        
        [HttpPost]
        [Route("adminGetAllUsers")]
        public async Task<IActionResult> AdminGetAllUser()
        {
            try
            {
                var result = await _adminService.GetAllUsers();
                Log.Information("Admin Get all function called");
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> RegisterUser([FromBody] Users newUser)
        {
            try
            {
                var result = await _userService.AddAsync(newUser);
                if (result == 1)
                {
                    return Ok("Completed");
                }
                else
                {
                    return BadRequest("ERROR OCCURRED");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

    }
}
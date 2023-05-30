using Business.Abstract;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    
    public class ManagementController : ControllerBase
    {
        private readonly IManagementService _managementService;

        public ManagementController(IManagementService managementService)
        {
            _managementService = managementService;
        }


        [HttpPost]
        [Route("createManagement")]
        public async Task<IActionResult> CreateManagementAsync([FromBody] ManagementDto managementDto)
        {
            try
            {
                await _managementService.CreateManagement(managementDto);
                Log.Information("Management Created");
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("sellManagementByUserId")]
        public async Task<IActionResult> SellManagementByUserId([FromBody] SellManagementDto sellManagementDto)
        {
            try
            {
                await _managementService.SellManagement(sellManagementDto.UserId, sellManagementDto.ManagementId);
                Log.Information($"{sellManagementDto.UserId} bought management");
                return Ok(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using ECommerce.BLL.DTOs;
using ECommerce.BLL.Services;

namespace ECommerce.API.Controllers
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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var response = await _userService.AddUserAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var response = await _userService.UpdateUserAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var request = new DeleteUserRequest { Id = id };
            var response = await _userService.DeleteUserAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var request = new GetAllUsersRequest();
            var response = await _userService.GetAllUsersAsync(request);
            return Ok(response);
        }
    }
}
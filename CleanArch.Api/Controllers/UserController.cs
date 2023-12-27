using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Interfaces;
using System.Threading.Tasks;
using MyProject.Application.Services;
using MyProject.Application.DTO.User;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestDTO user)
        {
            var userId = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, CreateUserRequestDTO user)
        {
            var result = await _userService.UpdateAsync(id, user);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
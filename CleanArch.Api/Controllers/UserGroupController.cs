using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Interfaces;
using MyProject.Application.IServices;
using MyProject.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route("api/usergroups")]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _userGroupService;

        public UserGroupController(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserGroups()
        {
            try
            {
                var userGroups = await _userGroupService.GetAllAsync();
                return Ok(userGroups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserGroupById(int id)
        {
            try
            {
                var userGroup = await _userGroupService.GetByIdAsync(id);
                if (userGroup == null)
                {
                    return NotFound();
                }

                return Ok(userGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserGroup([FromBody] UserGroup userGroup)
        {
            try
            {
                var createdUserGroupId = await _userGroupService.CreateAsync(userGroup);
                return CreatedAtAction(nameof(GetUserGroupById), new { id = createdUserGroupId }, userGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserGroup(int id, [FromBody] UserGroup userGroup)
        {
            try
            {
                var success = await _userGroupService.UpdateAsync(id, userGroup);
                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroup(int id)
        {
            try
            {
                var success = await _userGroupService.DeleteAsync(id);
                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
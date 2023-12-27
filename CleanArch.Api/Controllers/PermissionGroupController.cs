using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Interfaces;
using MyProject.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route("api/permissiongroups")]
    public class PermissionGroupController : ControllerBase
    {
        private readonly IPermissionGroupService _permissionGroupService;

        public PermissionGroupController(IPermissionGroupService permissionGroupService)
        {
            _permissionGroupService = permissionGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissionGroups()
        {
            try
            {
                var permissionGroups = await _permissionGroupService.GetAllAsync();
                return Ok(permissionGroups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionGroupById(int id)
        {
            try
            {
                var permissionGroup = await _permissionGroupService.GetByIdAsync(id);
                if (permissionGroup == null)
                {
                    return NotFound();
                }

                return Ok(permissionGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissionGroup([FromBody] PermissionGroup permissionGroup)
        {
            try
            {
                var createdPermissionGroupId = await _permissionGroupService.CreateAsync(permissionGroup);
                return CreatedAtAction(nameof(GetPermissionGroupById), new { id = createdPermissionGroupId }, permissionGroup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermissionGroup(int id, [FromBody] PermissionGroup permissionGroup)
        {
            try
            {
                var success = await _permissionGroupService.UpdateAsync(id, permissionGroup);
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
        public async Task<IActionResult> DeletePermissionGroup(int id)
        {
            try
            {
                var success = await _permissionGroupService.DeleteAsync(id);
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
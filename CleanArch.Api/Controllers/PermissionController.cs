using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Interfaces;
using MyProject.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            try
            {
                var permissions = await _permissionService.GetAllAsync();
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            try
            {
                var permission = await _permissionService.GetByIdAsync(id);
                if (permission == null)
                {
                    return NotFound();
                }

                return Ok(permission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] Permission permission)
        {
            try
            {
                var createdPermissionId = await _permissionService.CreateAsync(permission);
                return CreatedAtAction(nameof(GetPermissionById), new { id = createdPermissionId }, permission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, [FromBody] Permission permission)
        {
            try
            {
                var success = await _permissionService.UpdateAsync(id, permission);
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
        public async Task<IActionResult> DeletePermission(int id)
        {
            try
            {
                var success = await _permissionService.DeleteAsync(id);
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
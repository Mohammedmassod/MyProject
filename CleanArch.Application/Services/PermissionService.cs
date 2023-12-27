using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Application.Interfaces;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _permissionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _permissionRepository.GetAllAsync();
        }

        public async Task<int> CreateAsync(Permission permission)
        {
            var createdPermission = await _permissionRepository.AddAsync(permission);
            return createdPermission.Id;
        }

        public async Task<bool> UpdateAsync(int id, Permission permission)
        {
            var existingPermission = await _permissionRepository.GetByIdAsync(id);
            if (existingPermission == null)
            {
                return false;
            }

            existingPermission.Name = permission.Name;
            // Update other properties as needed

            await _permissionRepository.UpdateAsync(existingPermission);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingPermission = await _permissionRepository.GetByIdAsync(id);
            if (existingPermission == null)
            {
                return false;
            }

            await _permissionRepository.DeleteAsync(existingPermission);
            return true;
        }
    }
}
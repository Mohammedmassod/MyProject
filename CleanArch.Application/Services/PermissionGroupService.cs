using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Application.Interfaces;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;

namespace MyProject.Application.Services
{
    public class PermissionGroupService : IPermissionGroupService
    {
        private readonly IPermissionGroupRepository _permissionGroupRepository;

        public PermissionGroupService(IPermissionGroupRepository permissionGroupRepository)
        {
            _permissionGroupRepository = permissionGroupRepository;
        }

        public async Task<PermissionGroup> GetByIdAsync(int id)
        {
            return await _permissionGroupRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PermissionGroup>> GetAllAsync()
        {
            return await _permissionGroupRepository.GetAllAsync();
        }

        public async Task<int> CreateAsync(PermissionGroup permissionGroup)
        {
            var createdPermissionGroup = await _permissionGroupRepository.AddAsync(permissionGroup);
            return createdPermissionGroup.Id;
        }

        public async Task<bool> UpdateAsync(int id, PermissionGroup permissionGroup)
        {
            var existingPermissionGroup = await _permissionGroupRepository.GetByIdAsync(id);
            if (existingPermissionGroup == null)
            {
                return false;
            }

            existingPermissionGroup.Name = permissionGroup.Name;
            // Update other properties as needed

            await _permissionGroupRepository.UpdateAsync(existingPermissionGroup);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingPermissionGroup = await _permissionGroupRepository.GetByIdAsync(id);
            if (existingPermissionGroup == null)
            {
                return false;
            }

            await _permissionGroupRepository.DeleteAsync(existingPermissionGroup);
            return true;
        }
    }
}
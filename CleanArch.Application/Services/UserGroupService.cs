using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Application.Interfaces;
using MyProject.Application.IRepositores;
using MyProject.Application.IServices;
using MyProject.Domain.Entities;

namespace MyProject.Application.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupService(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public async Task<UserGroup> GetByIdAsync(int id)
        {
            return await _userGroupRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserGroup>> GetAllAsync()
        {
            return await _userGroupRepository.GetAllAsync();
        }

        public async Task<int> CreateAsync(UserGroup userGroup)
        {
            var createdUserGroup = await _userGroupRepository.AddAsync(userGroup);
            return createdUserGroup.Id;
        }

        public async Task<bool> UpdateAsync(int id, UserGroup userGroup)
        {
            var existingUserGroup = await _userGroupRepository.GetByIdAsync(id);
            if (existingUserGroup == null)
            {
                return false;
            }

            existingUserGroup.Name = userGroup.Name;
            // Update other properties as needed

            await _userGroupRepository.UpdateAsync(existingUserGroup);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingUserGroup = await _userGroupRepository.GetByIdAsync(id);
            if (existingUserGroup == null)
            {
                return false;
            }

            await _userGroupRepository.DeleteAsync(existingUserGroup);
            return true;
        }
    }
}
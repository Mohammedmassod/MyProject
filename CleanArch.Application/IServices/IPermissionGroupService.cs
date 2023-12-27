using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Application.Interfaces
{
    public interface IPermissionGroupService
    {
        Task<PermissionGroup> GetByIdAsync(int id);
        Task<IEnumerable<PermissionGroup>> GetAllAsync();
        Task<int> CreateAsync(PermissionGroup permissionGroup);
        Task<bool> UpdateAsync(int id, PermissionGroup permissionGroup);
        Task<bool> DeleteAsync(int id);
    }
}
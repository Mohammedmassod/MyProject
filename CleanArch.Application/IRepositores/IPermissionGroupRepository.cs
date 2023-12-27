using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Application.IRepositores
{
    public interface IPermissionGroupRepository
    {
        Task<PermissionGroup> GetByIdAsync(int id);
        Task<IEnumerable<PermissionGroup>> GetAllAsync();
        Task<PermissionGroup> AddAsync(PermissionGroup permissionGroup);
        Task UpdateAsync(PermissionGroup permissionGroup);
        Task DeleteAsync(PermissionGroup permissionGroup);
    }
}
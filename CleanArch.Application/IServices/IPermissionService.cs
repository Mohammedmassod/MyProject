using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<Permission> GetByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<int> CreateAsync(Permission permission);
        Task<bool> UpdateAsync(int id, Permission permission);
        Task<bool> DeleteAsync(int id);
    }
}
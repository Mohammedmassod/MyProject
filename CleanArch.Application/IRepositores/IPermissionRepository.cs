using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission> GetByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission> AddAsync(Permission permission);
        Task UpdateAsync(Permission permission);
        Task DeleteAsync(Permission permission);
    }
}
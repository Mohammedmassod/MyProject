using MyProject.Application.IRepositores;
using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class PermissionGroupRepositoryEF : IPermissionGroupRepository
    {
        public Task<PermissionGroup> AddAsync(PermissionGroup permissionGroup)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PermissionGroup permissionGroup)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PermissionGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PermissionGroup> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PermissionGroup permissionGroup)
        {
            throw new NotImplementedException();
        }
    }
}

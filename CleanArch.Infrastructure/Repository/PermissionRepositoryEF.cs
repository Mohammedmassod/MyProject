using MyProject.Application.IRepositores;
using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class PermissionRepositoryEF : IPermissionRepository
    {
        public Task<Permission> AddAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}

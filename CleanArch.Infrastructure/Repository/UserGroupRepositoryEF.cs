using MyProject.Application.IRepositores;
using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class UserGroupRepositoryEF : IUserGroupRepository
    {
        public Task<UserGroup> AddAsync(UserGroup userGroup)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserGroup userGroup)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserGroup> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserGroup userGroup)
        {
            throw new NotImplementedException();
        }
    }
}

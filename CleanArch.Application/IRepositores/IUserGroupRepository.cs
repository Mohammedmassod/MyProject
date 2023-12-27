using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application.IRepositores
{
    public interface IUserGroupRepository
    {
        Task<UserGroup> GetByIdAsync(int id);
        Task<IEnumerable<UserGroup>> GetAllAsync();
        Task<UserGroup> AddAsync(UserGroup userGroup);
        Task UpdateAsync(UserGroup userGroup);
        Task DeleteAsync(UserGroup userGroup);
    }
}

using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application.IServices
{
    
        public interface IUserGroupService
        {
            Task<UserGroup> GetByIdAsync(int id);
            Task<IEnumerable<UserGroup>> GetAllAsync();
            Task<int> CreateAsync(UserGroup userGroup);
            Task<bool> UpdateAsync(int id, UserGroup userGroup);
            Task<bool> DeleteAsync(int id);
        }
    }


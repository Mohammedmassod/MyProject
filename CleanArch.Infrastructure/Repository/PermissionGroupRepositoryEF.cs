using MyProject.Application.IRepositores;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyProject.Infrastructure.Repository
{
    public class PermissionGroupRepositoryEF : IPermissionGroupRepository
    {
        private readonly AppDbContext _context;

        public PermissionGroupRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PermissionGroup> GetByIdAsync(int id)
        {
            return await _context.PermissionGroups.FindAsync(id);
        }

        public async Task<IEnumerable<PermissionGroup>> GetAllAsync()
        {
            var users = await _context.Users
                .Include(u => u.UserGroup)
                .AsNoTracking()
                .ToListAsync();
            return await _context.PermissionGroups.ToListAsync();
        }

        public async Task<PermissionGroup> AddAsync(PermissionGroup permissionGroup)
        {
            var newUser = new PermissionGroup
            {
                Id = permissionGroup.Id,
                Name = permissionGroup.Name,
              
                // Map other properties as needed
            };
            _context.PermissionGroups.Add(permissionGroup);
            await _context.SaveChangesAsync();
            return permissionGroup;
        }

        public async Task UpdateAsync(PermissionGroup permissionGroup)
        {
            _context.Entry(permissionGroup).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PermissionGroup permissionGroup)
        {
            _context.PermissionGroups.Remove(permissionGroup);
            await _context.SaveChangesAsync();
        }
    }
}
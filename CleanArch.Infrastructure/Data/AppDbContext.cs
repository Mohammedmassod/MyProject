using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Infrastructure.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

    }
}

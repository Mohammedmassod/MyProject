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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships using fluent API

            // User - UserGroup (one-to-many)
           /* modelBuilder.Entity<User>()
                .HasOne(u => u.UserGroup)
                .WithMany(ug => ug.Users)
                .HasForeignKey(u => u.Id);*/
            // UserGroup - PermissionGroup (one-to-one)
            /* modelBuilder.Entity<UserGroup>()
                 .HasOne(ug => ug.PermissionGroups)
                 .WithMany(pg => pg.UserGroups)
                 .HasForeignKey(ug => ug.UserGroupId);

             // Permission - PermissionGroup (many-to-one)
             modelBuilder.Entity<Permission>()
                 .HasOne(p => p.PermissionGroup)
                 .WithMany(pg => pg.Permissions)
                 .HasForeignKey(p => p.PermissionGroupId);*/
        }
    }
}
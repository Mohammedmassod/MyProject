using MyProject.Application.Interfaces;
using MyProject.Application.IRepositores;
using MyProject.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MyProject.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //AddTransient, AddScoped, or AddSingleton
            //services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepository, UserRepositoryEF>();
            services.AddTransient<IUserGroupRepository, UserGroupRepositoryEF>();
            services.AddTransient<IPermissionRepository, PermissionRepositoryEF>();
            services.AddTransient<IPermissionGroupRepository, PermissionGroupRepositoryEF>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

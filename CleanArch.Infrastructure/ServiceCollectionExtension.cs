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
           //services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepository, UserRepositoryEF>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

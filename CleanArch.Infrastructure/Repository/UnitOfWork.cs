using MyProject.Application.Interfaces;
using MyProject.Application.IRepositores;

namespace MyProject.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }

        public IUserRepository Users { get; set; }




    }
}

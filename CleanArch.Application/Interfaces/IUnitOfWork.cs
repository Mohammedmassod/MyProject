using MyProject.Application.IRepositores;

namespace MyProject.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        


    }
}

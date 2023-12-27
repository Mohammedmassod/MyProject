using MyProject.Application.IRepositores;
using MyProject.Domain.Entities;
using MyProject.Application.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Application.IRepositores
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserResponseDTO>> GetAllAsync();
        Task<UserResponseDTO> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateUserRequestDTO user);
        Task<bool> UpdateAsync(int id, CreateUserRequestDTO user);
        Task<bool> DeleteAsync(int id);
    }

    // Define similar interfaces for other entities if needed
}

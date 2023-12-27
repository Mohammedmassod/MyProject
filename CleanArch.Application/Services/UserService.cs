using MyProject.Application.Interfaces;
using MyProject.Application.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<UserResponseDTO> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(CreateUserRequestDTO user)
        {
            return await _unitOfWork.Users.CreateAsync(user);
        }

        public async Task<bool> UpdateAsync(int id, CreateUserRequestDTO user)
        {
            return await _unitOfWork.Users.UpdateAsync(id, user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork.Users.DeleteAsync(id);
        }
    }
}
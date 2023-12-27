using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProject.Application.DTO.User;
using MyProject.Application.IRepositores;
using MyProject.Infrastructure.Data;

namespace MyProject.Infrastructure.Repository
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            return MapUsersToUserResponseDTO(users);
        }

        public async Task<UserResponseDTO> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return MapUserToUserResponseDTO(user);
        }

        public async Task<int> CreateAsync(CreateUserRequestDTO user)
        {
            var newUser = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                // Map other properties as needed
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser.Id;
        }

        public async Task<bool> UpdateAsync(int id, CreateUserRequestDTO user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.IsActive = user.IsActive;
            existingUser.PhoneNumber = user.PhoneNumber;
            // Map other properties as needed

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private IEnumerable<UserResponseDTO> MapUsersToUserResponseDTO(IEnumerable<User> users)
        {
            return users.Select(user => new UserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive,
                PhoneNumber = user.PhoneNumber,
                // Map other properties as needed
            });
        }

        private UserResponseDTO MapUserToUserResponseDTO(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive,
                PhoneNumber = user.PhoneNumber,
                // Map other properties as needed
            };
        }
    }
}

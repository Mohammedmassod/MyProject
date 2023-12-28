using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Application.DTO.User;
using MyProject.Infrastructure.Data;
using MyProject.Domain.Validators;
using FluentValidation;
using System;
using MyProject.Application.IRepositores;

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
                .Include(u => u.UserGroup)
                .AsNoTracking()
                .ToListAsync();

            return MapUsersToUserResponseDTO(users);
        }

        public async Task<UserResponseDTO> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.UserGroup)
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
                UserGroupId = user.UserGroupId,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword
                // Map other properties as needed
            };

            var validator = new UserValidator();
            var validationResult = await validator.ValidateAsync(newUser);

            if (!validationResult.IsValid)
            {
                var validationErrors = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException(validationErrors);
            }

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
            existingUser.UserGroupId = user.UserGroupId;
            // Map other properties as needed

            var validator = new UserValidator();
            var validationResult = await validator.ValidateAsync(existingUser);

            if (!validationResult.IsValid)
            {
                var validationErrors = string.Join(Environment.NewLine, validationResult.Errors.Select(error => error.ErrorMessage));
                throw new ValidationException(validationErrors);
            }

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
                UserGroupId = user.UserGroupId,
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
                UserGroupId = user.UserGroupId,
                // Map other properties as needed
            };
        }
    }
}
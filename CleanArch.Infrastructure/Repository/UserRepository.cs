using MyProject.Domain.Entities;
using MyProject.Infrastructure.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Application.DTO.User;
using MyProject.Application.IRepositores;

namespace MyProject.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(UserQueries.AllUsers);
                return result.Select(user => new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    PhoneNumber = user.PhoneNumber,
                    // Map other properties as needed
                });
            }
        }

        public async Task<UserResponseDTO> GetByIdAsync(int id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<User>(UserQueries.UserById, new { Id = id });
                if (result == null)
                {
                    return null;
                }

                var userResponse = new UserResponseDTO
                {
                    Id = result.Id,
                    UserName = result.UserName,
                    Email = result.Email,
                    IsActive = result.IsActive,
                    PhoneNumber = result.PhoneNumber,
                    // Map other properties as needed
                };

                return userResponse;
            }
        }

        public async Task<int> CreateAsync(CreateUserRequestDTO user)
        {
            var entity = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive,
                PhoneNumber = user.PhoneNumber,
                // Map other properties as needed
            };

            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(UserQueries.AddUser, entity);
                return result;
            }
        }

        public async Task<bool> UpdateAsync(int id, CreateUserRequestDTO user)
        {
            var entity = new User
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive,
                PhoneNumber = user.PhoneNumber,
                // Map other properties as needed
            };

            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(UserQueries.UpdateUser, entity);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(UserQueries.DeleteUser, new { Id = id });
                return result > 0;
            }
        }
    }
}
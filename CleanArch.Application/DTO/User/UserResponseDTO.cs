using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyProject.Application.DTO.User
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }

        // Other properties as needed for displaying user details
    }

    // You can create other response DTOs for different operations
}

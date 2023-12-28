using MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application.DTO.User
{
        public class CreateUserRequestDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string UserName { get; set; }
            public bool IsActive { get; set; }
            public string PhoneNumber { get; set; }
            public int UserGroupId { get; set; }

        // Other properties as needed for creating a user
    }

    // You can create other request DTOs for different operations (update, delete, etc.)
}



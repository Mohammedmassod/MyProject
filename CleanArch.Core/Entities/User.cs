using MyProject.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyProject.Domain.Entities
{
    public class User : BaseEnity
    {
      
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; } 
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public UserGroup UserGroup { get; set; } 

    }
}

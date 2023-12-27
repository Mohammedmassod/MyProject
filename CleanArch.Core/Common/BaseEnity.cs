using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Common
{
    public class BaseEnity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name length should not exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}

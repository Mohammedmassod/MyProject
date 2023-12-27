using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class PermissionGroup : BaseEnity
    {
        public ICollection<UserGroup> UserGroup { get; set; }

    }
}
